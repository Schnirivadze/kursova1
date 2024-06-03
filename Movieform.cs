using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Kurs
{
	public partial class Movieform : Form
	{
		Movie movie;
		public Movieform(Movie movie)
		{
			InitializeComponent();
			this.movie = movie;
		}


		private void DownloadButton_Click(object sender, EventArgs e)
		{
			if (File.Exists($"./movies/{movie.Location}/film.mp4"))
			{
				DialogResult result = MessageBox.Show("Фільм знайдено, скачати?", "", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes) movie.Download();
			}
			else MessageBox.Show("film not found");
		}

		private void Movieform_Load(object sender, EventArgs e)
		{
			TitleLabel.Text = movie.Title;
			for (int starI = 0; starI < 10; starI++)
			{
				var star = new PictureBox();
				star.Image = (starI < movie.Rating) ? Properties.Resources.checked_star : Properties.Resources.unchecked_star;
				star.Location = new System.Drawing.Point(755 + 25 * starI, 65);
				star.Size = new System.Drawing.Size(25, 25);
				star.SizeMode = PictureBoxSizeMode.Zoom;
				star.TabStop = false;
				Controls.Add(star);
			}
			DurationLabel.Text = $"{(int)movie.Duration / 60}г.{(int)movie.Duration % 60}мін.";
			YearLabel.Text = $"{movie.Year}";
			GenreLabel.Text = movie.Genre;
			DirectorLabel.Text = movie.Director;
			StudioLabel.Text = movie.Studio;
			ActorsLabel.Text = "";
			if (File.Exists($"./movies/{movie.Location}/poster.jpg"))
			{
				PosterBox.Image = Image.FromFile($"./movies/{movie.Location}/poster.jpg");
			}
			else PosterBox.Image = Properties.Resources.Poster;

			foreach (var actor in movie.MainActors)
			{
				ActorsLabel.Text += $"{actor}; ";
			}
			OverviewLabel.Text = movie.Synopsis;
		}

		private void KeyDownHandler(object sender, KeyEventArgs e)
		{
			MessageBox.Show("[F1] Допомога", "Eлементи керування", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}
