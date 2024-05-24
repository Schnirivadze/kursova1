using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kurs
{
	public partial class Mainform : Form
	{
		public Mainform()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			MovieDatabase.Load();
		}
		private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "назвою (А-Я)";
		}

		private void аЯToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "назвою (Я-А)";
		}

		private void оцінкоюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "оцінкою";
		}

		private void розміромбільщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "розміром (більщі спочатку)";
		}

		private void розміромменщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "розміром (менщі спочатку)";
		}

		private void новизнаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "новизною";
		}

		private void button1_Click(object sender, EventArgs e)
		{

			string search_title = (TitleTextBox.Text != "") ? TitleTextBox.Text : null;
			string search_genre = (GenreComboBox.SelectedItem != null) ? GenreComboBox.SelectedItem.ToString() : null;
			string search_studio = (StudioTextBox.Text != "") ? StudioTextBox.Text : null;
			string search_director = (DirectorTextBox.Text != "") ? DirectorTextBox.Text : null;
			string search_actor = (ActorTextBox.Text != "") ? ActorTextBox.Text : null;
			var movies = MovieDatabase.SearchMovies(
				name: search_title,
				genre: search_genre,
				studio: search_studio,
			director: search_director,
				actor: search_actor
				);

			MoviesPanel.Controls.Clear() ;
			for (int movieIndex = 0; movieIndex < movies.Count; movieIndex++)
			{

				Movie movie = movies[movieIndex];

				var poster = new PictureBox();
				if (File.Exists($"./movies/{movie.Location}/poster.jpg"))
				{
					poster.Image = Image.FromFile($"./movies/{movie.Location}/poster.jpg");
				}
				else poster.Image = Properties.Resources.Poster;

				poster.Location = new System.Drawing.Point(0, 7);
				poster.Size = new System.Drawing.Size(156, 187);
				poster.SizeMode = PictureBoxSizeMode.Zoom;
				poster.TabStop = false;
				poster.Click += (s, ev) => OpenMovieDetails(movie);

				var studiolabel = new Label();
				studiolabel.AutoSize = true;
				studiolabel.Location = new System.Drawing.Point(167, 170);
				studiolabel.Size = new System.Drawing.Size(195, 16);
				studiolabel.Text = $"Студія: {movie.Studio}";

				var directorlabel = new Label();
				directorlabel.AutoSize = true;
				directorlabel.Location = new System.Drawing.Point(167, 145);
				directorlabel.Size = new System.Drawing.Size(64, 16);
				directorlabel.Text = $"Режисер: {movie.Director}";

				var actorslabel = new Label();
				actorslabel.AutoSize = true;
				actorslabel.Location = new System.Drawing.Point(380, 120);
				actorslabel.Size = new System.Drawing.Size(130, 50);
				actorslabel.Text = "Грали\n";
				foreach(var actor in movie.MainActors)
				{
					actorslabel.Text += $"\t{actor}";
				}

				var yearlabel = new Label();
				yearlabel.AutoSize = true;
				yearlabel.Location = new System.Drawing.Point(327, 95);
				yearlabel.Size = new System.Drawing.Size(60, 16);
				yearlabel.Text = $"Рік: {movie.Year}";

				var shortlabelText = new Label();
				shortlabelText.AutoSize = true;
				shortlabelText.Location = new System.Drawing.Point(472, 32);
				shortlabelText.Size = new System.Drawing.Size(106, 16);
				shortlabelText.Text = "Короткий зміст";

				var genrelabel = new Label();
				genrelabel.AutoSize = true;
				genrelabel.Location = new System.Drawing.Point(165, 120);
				genrelabel.Size = new System.Drawing.Size(126, 16);
				genrelabel.Text = $"Жанр: {movie.Genre}";

				var durationlabel = new Label();
				durationlabel.AutoSize = true;
				durationlabel.Location = new System.Drawing.Point(167, 95);
				durationlabel.Size = new System.Drawing.Size(135, 16);
				durationlabel.Text = $"Довжина: {(int)movie.Duration/60} ч. {(int)movie.Duration % 60} мін.";

				var titlelabel = new Label();
				titlelabel.AutoSize = true;
				titlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 238);
				titlelabel.Location = new System.Drawing.Point(163, 22);
				titlelabel.Size = new System.Drawing.Size(190, 29);
				titlelabel.Text = movie.Title;

				var shortoverview = new Label();
				shortoverview.BackColor = System.Drawing.Color.Transparent;
				shortoverview.Location = new System.Drawing.Point(472, 55);
				shortoverview.Size = new System.Drawing.Size(434, 139);
				shortoverview.Text =movie.Synopsis;
				shortoverview.TextAlign = System.Drawing.ContentAlignment.TopCenter;

				var groupBox = new System.Windows.Forms.GroupBox();
				groupBox.SuspendLayout();

				groupBox.Controls.Add(titlelabel);
				groupBox.Controls.Add(genrelabel);
				groupBox.Controls.Add(studiolabel);
				groupBox.Controls.Add(directorlabel);
				groupBox.Controls.Add(actorslabel);
				groupBox.Controls.Add(yearlabel);
				groupBox.Controls.Add(shortlabelText);
				groupBox.Controls.Add(durationlabel);
				groupBox.Controls.Add(shortoverview);
				groupBox.Controls.Add(poster);
				//stars
				for (int starI = 0; starI < (int)movie.Rating; starI++)
				{
					var star = new PictureBox();
					star.Image = Properties.Resources.Star;
					star.Location = new System.Drawing.Point(170 + 20 * starI, 55);
					star.Size = new System.Drawing.Size(20, 20);
					star.SizeMode = PictureBoxSizeMode.Zoom;
					star.TabStop = false;
					groupBox.Controls.Add(star);
				}
				groupBox.Location = new System.Drawing.Point(3, 3+206* movieIndex);
				groupBox.Size = new System.Drawing.Size(912, 200);
				groupBox.TabStop = false;
				groupBox.ResumeLayout(false);
				groupBox.PerformLayout();
				MoviesPanel.Controls.Add(groupBox);

			}
		}
		private void OpenMovieDetails(Movie movie)
		{
			// Create an instance of the new form, passing the message to the constructor
			Movieform newForm = new Movieform(movie);

			// Hide the current form (this)
			this.Hide();

			// Show the new form
			newForm.Show();

			// Handle the FormClosed event of the new form
			newForm.FormClosed += (s, args) => this.Show();
		}


		private void label9_Click(object sender, EventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}
