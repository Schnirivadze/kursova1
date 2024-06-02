using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace Kurs
{
	public partial class Mainform : Form
	{
		enum Sorting
		{
			ByNameAtoZ,
			ByNameZtoA,
			Rating,
			SizeBigtoSmall,
			SizeSmalltoBig,
			Recency
		}
		private Sorting sortingWay = Sorting.ByNameAtoZ;
		private List<Movie> movies;
		public Mainform()
		{
			InitializeComponent();
		}
		private void FilterMovies()
		{
			string search_title = (TitleTextBox.Text != "") ? TitleTextBox.Text : null;
			string search_genre = (GenreComboBox.SelectedItem != null) ? GenreComboBox.SelectedItem.ToString() : null;
			string search_studio = (StudioTextBox.Text != "") ? StudioTextBox.Text : null;
			string search_director = (DirectorTextBox.Text != "") ? DirectorTextBox.Text : null;
			string search_actor = (ActorTextBox.Text != "") ? ActorTextBox.Text : null;
			movies = MovieDatabase.SearchMovies(
				name: search_title,
				genre: search_genre,
				studio: search_studio,
			director: search_director,
				actor: search_actor
				);
		}
		private void SortMovies()
		{
			switch (sortingWay)
			{
				case Sorting.ByNameAtoZ:
					movies.Sort((x, y) => x.Title.CompareTo(y.Title));
					break;
				case Sorting.ByNameZtoA:
					movies.Sort((x, y) => y.Title.CompareTo(x.Title));
					break;
				case Sorting.Rating:
					movies.Sort((x, y) => y.Rating.CompareTo(x.Rating));
					break;
				case Sorting.SizeBigtoSmall:
					movies.Sort((x, y) => x.Size.CompareTo(y.Size));
					break;
				case Sorting.SizeSmalltoBig:
					movies.Sort((x, y) => y.Size.CompareTo(x.Size));
					break;
				case Sorting.Recency:
					movies.Sort((x, y) => y.Year.CompareTo(x.Year));
					break;
				default:

                    System.Windows.MessageBox.Show("Виникла проблема з сортуванням фільмів","",MessageBoxButton.OK, MessageBoxImage.Error);
					break;
			}
		}
		private void FillMoviesPreviews()
		{
			MoviesPanel.Controls.Clear();
			for (int movieIndex = 0; movieIndex < movies.Count; movieIndex++)
			{

				Movie movie = movies[movieIndex];

				var poster = new PictureBox();
				if (File.Exists($"./movies/{movie.Location}/poster.jpg"))
				{
					poster.Image = Image.FromFile($"./movies/{movie.Location}/poster.jpg");
				}
				else poster.Image = Properties.Resources.Poster;

				poster.Location = new Point(0, 7);
				poster.Size = new Size(156, 187);
				poster.SizeMode = PictureBoxSizeMode.Zoom;
				poster.TabStop = false;
				poster.Click += (s1, ev) =>
				{
					Movieform newForm = new Movieform(movie);
					this.Hide();
					newForm.Show();
					newForm.FormClosed += (s2, args) => this.Show();
				};

				var studiolabel = new Label();
				studiolabel.AutoSize = true;
				studiolabel.Location = new Point(167, 170);
				studiolabel.Size = new Size(195, 16);
				studiolabel.Text = $"Студія: {movie.Studio}";

				var directorlabel = new Label();
				directorlabel.AutoSize = true;
				directorlabel.Location = new Point(167, 145);
				directorlabel.Size = new Size(64, 16);
				directorlabel.Text = $"Режисер: {movie.Director}";

				var actorslabel = new Label();
				actorslabel.AutoSize = true;
				actorslabel.Location = new Point(380, 120);
				actorslabel.Size = new Size(130, 50);
				actorslabel.Text = "Грали";
				foreach (var actor in movie.MainActors)
				{
					actorslabel.Text += $"\n    {actor}";
				}

				var yearlabel = new Label();
				yearlabel.AutoSize = true;
				yearlabel.Location = new Point(327, 95);
				yearlabel.Size = new Size(60, 16);
				yearlabel.Text = $"Рік: {movie.Year}";

				var shortlabelText = new Label();
				shortlabelText.AutoSize = true;
				shortlabelText.Location = new Point(472, 32);
				shortlabelText.Size = new Size(106, 16);
				shortlabelText.Text = "Короткий зміст";

				var genrelabel = new Label();
				genrelabel.AutoSize = true;
				genrelabel.Location = new Point(165, 120);
				genrelabel.Size = new Size(126, 16);
				genrelabel.Text = $"Жанр: {movie.Genre}";

				var durationlabel = new Label();
				durationlabel.AutoSize = true;
				durationlabel.Location = new Point(167, 95);
				durationlabel.Size = new Size(135, 16);
				durationlabel.Text = $"Довжина: {(int)movie.Duration / 60} ч. {(int)movie.Duration % 60} мін.";

				var titlelabel = new Label();
				titlelabel.AutoSize = true;
				titlelabel.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
				titlelabel.Location = new Point(163, 22);
				titlelabel.Size = new Size(190, 29);
				titlelabel.Text = movie.Title;

				var shortoverview = new Label();
				shortoverview.BackColor = Color.Transparent;
				shortoverview.Location = new Point(472, 55);
				shortoverview.Size = new Size(434, 139);
				shortoverview.Text = movie.Synopsis;
				shortoverview.TextAlign = ContentAlignment.TopCenter;

				var groupBox = new GroupBox();
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
				for (int starI = 0; starI < 10; starI++)
				{
					var star = new PictureBox();
					star.Image = (starI < movie.Rating) ? Properties.Resources.checked_star : Properties.Resources.unchecked_star;
					star.Location = new Point(170 + 20 * starI, 55);
					star.Size = new Size(20, 20);
					star.SizeMode = PictureBoxSizeMode.Zoom;
					star.TabStop = false;
					groupBox.Controls.Add(star);
				}
				groupBox.Location = new Point(3, 3 + 206 * movieIndex);
				groupBox.Size = new Size(912, 200);
				groupBox.TabStop = false;
				groupBox.ResumeLayout(false);
				groupBox.PerformLayout();
				MoviesPanel.Controls.Add(groupBox);
				
			}
			// 
			// UploadButton
			// 
			Button UploadButton = new Button();
			UploadButton.Location = new Point(3, 3);
			UploadButton.Size = new Size(912, 40);
			UploadButton.TabIndex = 0;
			UploadButton.Text = "Завантажити фільм";
			UploadButton.UseVisualStyleBackColor = true;
			UploadButton.Click += (object s, EventArgs ev) => {
				UploadForm newForm = new UploadForm();
				this.Hide();
				newForm.Show();
				newForm.FormClosed += (s2, args) => this.Show();
			};

			MoviesPanel.Controls.Add(UploadButton);
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			MovieDatabase.Load();
		}
		private void аЯToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "назвою (А-Я)";
			sortingWay = Sorting.ByNameAtoZ;
			SortMovies();
			FillMoviesPreviews();
		}

		private void аЯToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "назвою (Я-А)";
			sortingWay = Sorting.ByNameZtoA;
			SortMovies();
			FillMoviesPreviews();
		}

		private void оцінкоюToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "оцінкою";
			sortingWay = Sorting.Rating;
			SortMovies();
			FillMoviesPreviews();
		}

		private void розміромбільщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "розміром (більщі спочатку)";
			sortingWay = Sorting.SizeBigtoSmall;
			SortMovies();
			FillMoviesPreviews();
		}

		private void розміромменщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "розміром (менщі спочатку)";
			sortingWay = Sorting.SizeSmalltoBig;
			SortMovies();
			FillMoviesPreviews();
		}

		private void новизнаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.FilterLabel.Text = "новизною";
			sortingWay = Sorting.Recency;
			SortMovies();
			FillMoviesPreviews();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FilterMovies();
			SortMovies();
			FillMoviesPreviews();
		}
	}
}
