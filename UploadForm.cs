using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kurs
{
	public partial class UploadForm : Form
	{
		private Movie newMovie;
		private string moviePath = string.Empty;
		private string posterPath = string.Empty;

		public UploadForm()
		{
			InitializeComponent();
			newMovie = new Movie();
			InitializeStarClickEvents();
			AttachClearBackColorEventHandler();
			this.KeyDown += KeyDownHandler;
		}

		private void InitializeStarClickEvents()
		{
			for (int i = 1; i <= 10; i++)
			{
				var starBox = Controls.Find($"starBox{i}", true).FirstOrDefault() as PictureBox;
				if (starBox != null)
				{
					int rating = i;
					starBox.Click += (sender, e) => SetRating(rating);
				}
			}
		}

		private void SetRating(int rating)
		{
			newMovie.Rating = rating;
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
			HandleFileDrop(e, ".mp4", ref moviePath, MovieDropArea);
		}

		private void PosterDropArea_DragDrop(object sender, DragEventArgs e)
		{
			HandleFileDrop(e, ".jpg", ref posterPath, PosterDropArea);
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

			if (string.IsNullOrWhiteSpace(moviePath))
			{
				messages.Add("Завантажте фільм");
				MovieDropArea.BackColor = Color.Red;
			}

			if (string.IsNullOrWhiteSpace(posterPath))
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
				newMovie = new Movie
				{
					Title = TitleTextBox.Text,
					Duration = GetDuration(),
					Year = (int)YearTextBox.Value,
					Genre = GenreComboBox.Text,
					Director = DirectorTextBox.Text,
					Studio = StudioTextBox.Text,
					MainActors = ActorsRichTextBox.Text.Split('\n').ToList(),
					Synopsis = OverviewRichTextBox.Text,
					Rating = newMovie.Rating
				};

				try
				{
					UploadButton.Text = "Завантажується";
					UploadButton.Enabled = false;
					MovieDatabase.AddMovie(newMovie, moviePath, posterPath);
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

		private void KeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				ShowHelpWindow();
			}
		}

		private void ShowHelpWindow()
		{
			string helpMessage = "Для додавання рейтингу фільму використовуйте зірочки.\n" +
								 "Для завантаження фільму та постера перетягніть відповідні файли у відповідні області.\n" +
								 "Заповніть всі обов'язкові поля перед завантаженням.\n" +
								 "Натисніть кнопку 'Завантажити' для завершення процесу.";
			MessageBox.Show(helpMessage, "Допомога - Завантаження фільму", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void ClearBackColor(object sender, EventArgs e)
		{
			if (sender is Control control)
			{
				control.BackColor = Color.White;
			}
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.KeyDown -= KeyDownHandler;
				foreach (Control control in Controls)
				{
					control.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		// Attach the event handler to the relevant controls in the form designer
		private void AttachClearBackColorEventHandler()
		{
			TitleTextBox.Click += ClearBackColor;
			DurationHours.Click += ClearBackColor;
			DurationMinutes.Click += ClearBackColor;
			GenreComboBox.Click += ClearBackColor;
			DirectorTextBox.Click += ClearBackColor;
			StudioTextBox.Click += ClearBackColor;
			ActorsRichTextBox.Click += ClearBackColor;
			OverviewRichTextBox.Click += ClearBackColor;
		}
	}
}
