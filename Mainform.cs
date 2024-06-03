using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
			string search_title = !string.IsNullOrEmpty(TitleTextBox.Text) ? TitleTextBox.Text : null;
			string search_genre = GenreComboBox.SelectedItem != null ? GenreComboBox.SelectedItem.ToString() : null;
			string search_studio = !string.IsNullOrEmpty(StudioTextBox.Text) ? StudioTextBox.Text : null;
			string search_director = !string.IsNullOrEmpty(DirectorTextBox.Text) ? DirectorTextBox.Text : null;
			string search_actor = !string.IsNullOrEmpty(ActorTextBox.Text) ? ActorTextBox.Text : null;

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
					movies.Sort((x, y) => y.Size.CompareTo(x.Size));
					break;
				case Sorting.SizeSmalltoBig:
					movies.Sort((x, y) => x.Size.CompareTo(y.Size));
					break;
				case Sorting.Recency:
					movies.Sort((x, y) => y.Year.CompareTo(x.Year));
					break;
				default:
					MessageBox.Show("Виникла проблема з сортуванням фільмів", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}

        private void FillMoviesPreviews()
        {
            MoviesPanel.Controls.Clear();
            foreach (var movie in movies)
            {
                var poster = new PictureBox
                {
                    Image = File.Exists($"./movies/{movie.Location}/poster.jpg")
                        ? Image.FromFile($"./movies/{movie.Location}/poster.jpg")
                        : Properties.Resources.Poster,
                    Location = new Point(0, 7),
                    Size = new Size(156, 187),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    TabStop = false
                };
                poster.Click += (s, ev) =>
                {
                    var newForm = new Movieform(movie);
                    Hide();
                    newForm.Show();
                    newForm.FormClosed += (s2, args) => Show();
                };

                var labels = new[]
                {
                    new Label { Location = new Point(167, 170), Size = new Size(195, 16), Text = $"Студія: {movie.Studio}" },
                    new Label { Location = new Point(167, 145), Size = new Size(64, 16), Text = $"Режисер: {movie.Director}" },
                    new Label { Location = new Point(380, 120), Size = new Size(130, 50), Text = $"Грали\n    {string.Join("\n    ", movie.MainActors)}" },
                    new Label { Location = new Point(327, 95), Size = new Size(60, 16), Text = $"Рік: {movie.Year}" },
                    new Label { Location = new Point(472, 32), Size = new Size(106, 16), Text = "Короткий зміст" },
                    new Label { Location = new Point(165, 120), Size = new Size(126, 16), Text = $"Жанр: {movie.Genre}" },
                    new Label { Location = new Point(167, 95), Size = new Size(135, 16), Text = $"Довжина: {(int)movie.Duration / 60} ч. {(int)movie.Duration % 60} мін." },
                    new Label { Location = new Point(163, 22), Size = new Size(190, 29), Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238), Text = movie.Title },
                    new Label { Location = new Point(472, 55), Size = new Size(434, 139), TextAlign = ContentAlignment.TopCenter, Text = movie.Synopsis, BackColor = Color.Transparent }
                };

                var groupBox = new GroupBox
                {
                    Location = new Point(3, 3 + 206 * movies.IndexOf(movie)),
                    Size = new Size(912, 200),
                    TabStop = false
                };
                groupBox.Controls.AddRange(labels);
                groupBox.Controls.Add(poster);

                for (int starI = 0; starI < 10; starI++)
                {
                    var star = new PictureBox
                    {
                        Image = starI < movie.Rating ? Properties.Resources.checked_star : Properties.Resources.unchecked_star,
                        Location = new Point(170 + 20 * starI, 55),
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        TabStop = false
                    };
                    groupBox.Controls.Add(star);
                }

                MoviesPanel.Controls.Add(groupBox);
            }

            var uploadButton = new Button
            {
                Location = new Point(3, 3),
                Size = new Size(912, 40),
                TabIndex = 0,
                Text = "Завантажити фільм",
                UseVisualStyleBackColor = true
            };
            uploadButton.Click += (s, ev) =>
            {
                var newForm = new UploadForm();
                Hide();
                newForm.Show();
                newForm.FormClosed += (s2, args) => Show();
            };
            MoviesPanel.Controls.Add(uploadButton);
        }

        private void Form1_Load(object sender, EventArgs e) => MovieDatabase.Load();

        private void SortAndFillMovies(Sorting sortingWay)
        {
            this.sortingWay = sortingWay;
            SortMovies();
            FillMoviesPreviews();
        }

        private void аЯToolStripMenuItem_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.ByNameAtoZ);
        private void аЯToolStripMenuItem1_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.ByNameZtoA);
        private void оцінкоюToolStripMenuItem_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.Rating);
        private void розміромбільщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.SizeBigtoSmall);
        private void розміромменщіСпочаткуToolStripMenuItem_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.SizeSmalltoBig);
        private void новизнаToolStripMenuItem_Click(object sender, EventArgs e) => SortAndFillMovies(Sorting.Recency);

        private void FilterSortFillMovies()
        {
            FilterMovies();
            SortMovies();
            FillMoviesPreviews();
        }

        private void button1_Click(object sender, EventArgs e) => FilterSortFillMovies();

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) ShowHelpWindow();
            else if (e.KeyCode == Keys.Enter) FilterSortFillMovies();
        }

        private void допомогаToolStripMenuItem_Click(object sender, EventArgs e) => ShowHelpWindow();

        private void ShowHelpWindow()
        {
            MessageBox.Show("[F1] Допомога\n[Enter] Пошук\n[Tab] Наступне поле\n[Shift+Tab] Попереднє поле", "Eлементи керування", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
