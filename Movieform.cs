using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Kurs
{
	public partial class MovieForm : Form
	{
		private Movie movie;

		public MovieForm(Movie movie)
		{
			InitializeComponent();
			this.movie = movie ?? throw new ArgumentNullException(nameof(movie));
			this.Load += MovieForm_Load;
			this.KeyDown += KeyDownHandler;
		}

		private void DownloadButton_Click(object sender, EventArgs e)
		{
			string moviePath = Path.Combine("./movies", movie.Location, "film.mp4");
			if (File.Exists(moviePath))
			{
				DialogResult result = MessageBox.Show("Фільм знайдено, скачати?", "", MessageBoxButtons.YesNo);
				if (result == DialogResult.Yes)
				{
					try
					{
						movie.Download();
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Error downloading movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			else
			{
				MessageBox.Show("Фільм не знайдено");
			}
		}

		private void MovieForm_Load(object sender, EventArgs e)
		{
			TitleLabel.Text = movie.Title;

			for (int starIndex = 0; starIndex < 10; starIndex++)
			{
				var star = new PictureBox
				{
					Image = (starIndex < movie.Rating) ? Properties.Resources.checked_star : Properties.Resources.unchecked_star,
					Location = new Point(755 + 25 * starIndex, 65),
					Size = new Size(25, 25),
					SizeMode = PictureBoxSizeMode.Zoom,
					TabStop = false
				};
				Controls.Add(star);
			}

			DurationLabel.Text = $"{(int)movie.Duration / 60}г.{(int)movie.Duration % 60}мін.";
			YearLabel.Text = $"{movie.Year}";
			GenreLabel.Text = movie.Genre;
			DirectorLabel.Text = movie.Director;
			StudioLabel.Text = movie.Studio;
			ActorsLabel.Text = string.Join("; ", movie.MainActors);

			string posterPath = Path.Combine("./movies", movie.Location, "poster.jpg");
			if (File.Exists(posterPath))
			{
				try
				{
					PosterBox.Image = Image.FromFile(posterPath);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error loading poster image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					PosterBox.Image = Properties.Resources.Poster;
				}
			}
			else
			{
				PosterBox.Image = Properties.Resources.Poster;
			}

			OverviewLabel.Text = movie.Synopsis;
		}

		private void KeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				MessageBox.Show("[F1] Допомога", "Елементи керування", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Load -= MovieForm_Load;
				this.KeyDown -= KeyDownHandler;
				PosterBox?.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}