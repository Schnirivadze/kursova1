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
		}

		private void starBox1_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 1;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.unchecked_star;
			starBox3.BackgroundImage = Properties.Resources.unchecked_star;
			starBox4.BackgroundImage = Properties.Resources.unchecked_star;
			starBox5.BackgroundImage = Properties.Resources.unchecked_star;
			starBox6.BackgroundImage = Properties.Resources.unchecked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox2_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 2;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.unchecked_star;
			starBox4.BackgroundImage = Properties.Resources.unchecked_star;
			starBox5.BackgroundImage = Properties.Resources.unchecked_star;
			starBox6.BackgroundImage = Properties.Resources.unchecked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox3_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 3;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.unchecked_star;
			starBox5.BackgroundImage = Properties.Resources.unchecked_star;
			starBox6.BackgroundImage = Properties.Resources.unchecked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox4_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 4;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.unchecked_star;
			starBox6.BackgroundImage = Properties.Resources.unchecked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox5_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 5;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.unchecked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox6_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 6;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.checked_star;
			starBox7.BackgroundImage = Properties.Resources.unchecked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox7_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 7;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.checked_star;
			starBox7.BackgroundImage = Properties.Resources.checked_star;
			starBox8.BackgroundImage = Properties.Resources.unchecked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox8_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 8;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.checked_star;
			starBox7.BackgroundImage = Properties.Resources.checked_star;
			starBox8.BackgroundImage = Properties.Resources.checked_star;
			starBox9.BackgroundImage = Properties.Resources.unchecked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox9_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 9;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.checked_star;
			starBox7.BackgroundImage = Properties.Resources.checked_star;
			starBox8.BackgroundImage = Properties.Resources.checked_star;
			starBox9.BackgroundImage = Properties.Resources.checked_star;
			starBox10.BackgroundImage = Properties.Resources.unchecked_star;
		}

		private void starBox10_Click(object sender, EventArgs e)
		{
			new_movie.Rating = 10;
			starBox1.BackgroundImage = Properties.Resources.checked_star;
			starBox2.BackgroundImage = Properties.Resources.checked_star;
			starBox3.BackgroundImage = Properties.Resources.checked_star;
			starBox4.BackgroundImage = Properties.Resources.checked_star;
			starBox5.BackgroundImage = Properties.Resources.checked_star;
			starBox6.BackgroundImage = Properties.Resources.checked_star;
			starBox7.BackgroundImage = Properties.Resources.checked_star;
			starBox8.BackgroundImage = Properties.Resources.checked_star;
			starBox9.BackgroundImage = Properties.Resources.checked_star;
			starBox10.BackgroundImage = Properties.Resources.checked_star;
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
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0 && (files[0].EndsWith(".mp4", StringComparison.OrdinalIgnoreCase)))
			{
				MovieDropArea.BackColor = Color.Green;
				movie_path = files[0];
				MovieDropArea.BackgroundImage = Properties.Resources.check_circle;
			}
			else
			{
				MessageBox.Show("Тип файлу не підтримується. Додайте файл MP4", "Непідтримуваний тип файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void PosterDropArea_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0 && (files[0].EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)))
			{
				PosterDropArea.BackColor = Color.Green;
				poster_path = files[0];
				PosterDropArea.BackgroundImage = Properties.Resources.check_circle;
			}
			else
			{
				MessageBox.Show("Тип файлу не підтримується. Додайте файл JPG", "Непідтримуваний тип файлу", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private int GetDuration()
		{
			return (int)(DurationHours.Value * 60 + DurationMinutes.Value);
		}
		private bool ValidateForm()
		{
			string message = "";
			int number_of_violations = 0;
			if (TitleTextBox.Text == "")
			{
				message = "Заповніть назву фільму";
				number_of_violations++;
				TitleTextBox.BackColor = Color.Red;
			}
			if (GetDuration() == 0)
			{
				message = "Заповніть довжину фільму";
				number_of_violations++;
				DurationHours.BackColor = Color.Red;
				DurationMinutes.BackColor = Color.Red;
			}
			if (GenreComboBox.Text == "")
			{
				message = "Заповніть жанр фільму";
				number_of_violations++;
				GenreComboBox.BackColor = Color.Red;
			}
			if (StudioTextBox.Text == "")
			{
				message = "Заповніть студію фільму";
				number_of_violations++;
				StudioTextBox.BackColor = Color.Red;
			}
			if (DirectorTextBox.Text == "")
			{
				message = "Заповніть режисера фільму";
				number_of_violations++;
				DirectorTextBox.BackColor = Color.Red;
			}
			if (ActorsRichTextBox.Text == "")
			{
				message = "Заповніть акторів фільму";
				number_of_violations++;
				ActorsRichTextBox.BackColor = Color.Red;
			}
			if (OverviewRichTextBox.Text == "")
			{
				message = "Заповніть зміст фільму";
				number_of_violations++;
				OverviewRichTextBox.BackColor = Color.Red;
			}
			if (movie_path == "")
			{
				message = "Завантажте фільм";
				number_of_violations++;
				MovieDropArea.BackColor = Color.Red;
			}
			if (poster_path == "")
			{
				message = "Завантажте постер";
				number_of_violations++;
				PosterDropArea.BackColor = Color.Red;
			}



			if (number_of_violations > 1)
			{
				MessageBox.Show("Заповніть виділені поля", "Помилка при заповнені форми", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			if (number_of_violations == 1)
			{
				MessageBox.Show(message, "Помилка при заповнені форми", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return false;
			}
			else return true;
		}
		private void UploadButton_Click(object sender, EventArgs e)
		{
			if (ValidateForm())
			{
				List<string> actors = new List<string>();
				actors.AddRange(ActorsRichTextBox.Text.Split('\n'));
				new_movie.Title = TitleTextBox.Text;
				new_movie.Duration = GetDuration();
				new_movie.Year = (int)YearTextBox.Value;
				new_movie.Genre = GenreComboBox.Text;
				new_movie.Director = DirectorTextBox.Text;
				new_movie.Studio = StudioTextBox.Text;
				new_movie.MainActors = actors;
				new_movie.Synopsis = OverviewRichTextBox.Text;
				UploadButton.Text = "Завантажується";
				UploadButton.Enabled = false;
				MovieDatabase.AddMovie(new_movie,movie_path,poster_path);
				MessageBox.Show("Фільм завантажено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}

		private void DurationHours_Click(object sender, EventArgs e)
		{
			DurationHours.BackColor = Color.White;
		}

		private void DurationMinutes_Click(object sender, EventArgs e)
		{
			DurationMinutes.BackColor = Color.White;
		}

		private void TitleTextBox_Click(object sender, EventArgs e)
		{
			TitleTextBox.BackColor = Color.White;
		}
		
		private void GenreComboBox_Click(object sender, EventArgs e)
		{
			GenreComboBox.BackColor = Color.White;
		}
		
		private void DirectorTextBox_Click(object sender, EventArgs e)
		{
			DirectorTextBox.BackColor = Color.White;
		}

		private void StudioTextBox_Click(object sender, EventArgs e)
		{
			StudioTextBox.BackColor = Color.White;
		}

		private void ActorsRichTextBox_Click(object sender, EventArgs e)
		{
			ActorsRichTextBox.BackColor = Color.White;
		}

		private void OverviewRichTextBox_Click(object sender, EventArgs e)
		{
			OverviewRichTextBox.BackColor = Color.White;
		}
	}
}
