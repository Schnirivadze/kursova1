using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kurs
{
	public partial class UploadForm : Form
	{
		Movie new_movie;
		string movie_path = "";
		string poster_path = "";

		public UploadForm()
		{
			InitializeComponent();
			new_movie = new Movie();
			InitializeStarClickEvents();
		}

		private void InitializeStarClickEvents()
		{
			starBox1.Click += (sender, e) => SetRating(1);
			starBox2.Click += (sender, e) => SetRating(2);
			starBox3.Click += (sender, e) => SetRating(3);
			starBox4.Click += (sender, e) => SetRating(4);
			starBox5.Click += (sender, e) => SetRating(5);
			starBox6.Click += (sender, e) => SetRating(6);
			starBox7.Click += (sender, e) => SetRating(7);
			starBox8.Click += (sender, e) => SetRating(8);
			starBox9.Click += (sender, e) => SetRating(9);
			starBox10.Click += (sender, e) => SetRating(10);
		}

		private void SetRating(int rating)
		{
			new_movie.Rating = rating;
			for (int i = 1; i <= 10; i++)
			{
				var starBox = Controls.Find($"starBox{i}", true).FirstOrDefault() as PictureBox;
				if (starBox != null)
				{
					starBox.BackgroundImage = i <= rating ? Properties.Resources.checked_star : Properties.Resources.unchecked_star;
				}
			}
		}

		private void DropArea_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Move;
			}
		}

		private void MovieDropArea_DragDrop(object sender, DragEventArgs e)
		{
			HandleFileDrop(e, ".mp4", ref movie_path, MovieDropArea);
		}

		private void PosterDropArea_DragDrop(object sender, DragEventArgs e)
		{
			HandleFileDrop(e, ".jpg", ref poster_path, PosterDropArea);
		}

		private void HandleFileDrop(DragEventArgs e, string expectedExtension, ref string filePath, Panel dropArea)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0 && files[0].EndsWith(expectedExtension, StringComparison.OrdinalIgnoreCase))
			{
				dropArea.BackColor = Color.Green;
				filePath = files[0];
				dropArea.BackgroundImage = Properties.Resources.check_circle;
			}
			else
			{
				MessageBox.Show($"Тип файлу не підтримується. Додайте файл {expectedExtension.ToUpper()}", "Непідтримуваний тип файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private int GetDuration()
		{
			return (int)(DurationHours.Value * 60 + DurationMinutes.Value);
		}

		private bool ValidateForm()
		{
			var messages = new List<string>();
			if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
			{
				messages.Add("Заповніть назву фільму");
				TitleTextBox.BackColor = Color.Red;
			}
			if (GetDuration() == 0)
			{
				messages.Add("Заповніть довжину фільму");
				DurationHours.BackColor = Color.Red;
				DurationMinutes.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(GenreComboBox.Text))
			{
				messages.Add("Заповніть жанр фільму");
				GenreComboBox.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(StudioTextBox.Text))
			{
				messages.Add("Заповніть студію фільму");
				StudioTextBox.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(DirectorTextBox.Text))
			{
				messages.Add("Заповніть режисера фільму");
				DirectorTextBox.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(ActorsRichTextBox.Text))
			{
				messages.Add("Заповніть акторів фільму");
				ActorsRichTextBox.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(OverviewRichTextBox.Text))
			{
				messages.Add("Заповніть зміст фільму");
				OverviewRichTextBox.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(movie_path))
			{
				messages.Add("Завантажте фільм");
				MovieDropArea.BackColor = Color.Red;
			}
			if (string.IsNullOrWhiteSpace(poster_path))
			{
				messages.Add("Завантажте постер");
				PosterDropArea.BackColor = Color.Red;
			}

			if (messages.Any())
			{
				MessageBox.Show(string.Join("\n", messages), "Помилка при заповнені форми", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}

			return true;
		}

		private void UploadButton_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				List<string> actors = new List<string>(ActorsRichTextBox.Text.Split('\n'));
				new_movie.Title = TitleTextBox.Text;
				new_movie.Duration = GetDuration();
				new_movie.Year = (int)YearTextBox.Value;
				new_movie.Genre = GenreComboBox.Text;
				new_movie.Director = DirectorTextBox.Text;
				new_movie.Studio = StudioTextBox.Text;
				new_movie.MainActors = actors;
				new_movie.Synopsis = OverviewRichTextBox.Text;

				try
				{
					UploadButton.Text = "Завантажується";
					UploadButton.Enabled = false;
					MovieDatabase.AddMovie(new_movie, movie_path, poster_path);
					MessageBox.Show("Фільм завантажено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Сталася помилка при завантаженні фільму: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					UploadButton.Text = "Завантажити";
					UploadButton.Enabled = true;
				}
			}
		}

		private void DurationHours_Click(object sender, EventArgs e) => DurationHours.BackColor = Color.White;
		private void DurationMinutes_Click(object sender, EventArgs e) => DurationMinutes.BackColor = Color.White;
		private void TitleTextBox_Click(object sender, EventArgs e) => TitleTextBox.BackColor = Color.White;
		private void GenreComboBox_Click(object sender, EventArgs e) => GenreComboBox.BackColor = Color.White;
		private void DirectorTextBox_Click(object sender, EventArgs e) => DirectorTextBox.BackColor = Color.White;
		private void StudioTextBox_Click(object sender, EventArgs e) => StudioTextBox.BackColor = Color.White;
		private void ActorsRichTextBox_Click(object sender, EventArgs e) => ActorsRichTextBox.BackColor = Color.White;
		private void OverviewRichTextBox_Click(object sender, EventArgs e) => OverviewRichTextBox.BackColor = Color.White;

		private void KeyDownHandler(object sender, KeyEventArgs e)
		{
			string helpMessage = "Для додавання рейтингу фільму використовуйте зірочки.\n" +
						"Для завантаження фільму та постера перетягніть відповідні файли у відповідні області.\n" +
						"Заповніть всі обов'язкові поля перед завантаженням.\n" +
						"Натисніть кнопку 'Завантажити' для завершення процесу.";

			MessageBox.Show(helpMessage, "Допомога - Завантаження фільму", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
