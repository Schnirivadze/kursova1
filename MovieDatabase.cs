using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Kurs
{
	public class Movie
	{
		public string Title { get; set; }
		public string Studio { get; set; }
		public string Genre { get; set; }
		public int Year { get; set; }
		public string Director { get; set; }
		public List<string> MainActors { get; set; }
		public string Synopsis { get; set; }
		public double Rating { get; set; }
		public string Location { get; set; }
		public double Size { get; set; } // GB
		public double Duration { get; set; } // minutes
		public override string ToString()
		{
			return $"{Title}({Genre}) by {Studio} in {Year} directed by {Director}";
		}
		public void Download()
		{
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
				saveFileDialog.Title = "Save a Text File";

				// Show the SaveFileDialog and check if the user clicked the save button
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Get the file path selected by the user
					string filePath = saveFileDialog.FileName;

					// Write content to the file

					// Save the content to the file
					try
					{
						File.Copy($"./movies/{Location}/film.mp4", filePath);
						MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}

	public class MovieDatabase
	{
		static private List<Movie> movies;
		static private string filePath = "movies.json";


		static public void AddMovie(Movie movie)
		{
			movies.Add(movie);
			RemoveDuplicates();
		}

		static public void RemoveMovie(string title)
		{
			movies.RemoveAll(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
			RemoveDuplicates();
		}

		static public void UpdateMovie(string title, Movie updatedMovie)
		{
			var movie = movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
			if (movie != null)
			{
				movie.Studio = updatedMovie.Studio;
				movie.Genre = updatedMovie.Genre;
				movie.Year = updatedMovie.Year;
				movie.Director = updatedMovie.Director;
				movie.MainActors = updatedMovie.MainActors;
				movie.Synopsis = updatedMovie.Synopsis;
				movie.Rating = updatedMovie.Rating;
				movie.Location = updatedMovie.Location;
				movie.Size = updatedMovie.Size;
				movie.Duration = updatedMovie.Duration;
				Save();
			}
		}

		static public Movie GetMovie(string title)
		{
			return movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		}

		static public List<Movie> SearchMovies(string name = null, string studio = null, string genre = null, int? year = null, string director = null, string actor = null)
		{
			return movies.Where(m =>
				(name == null || m.Title.Equals(name, StringComparison.OrdinalIgnoreCase)) &&
				(studio == null || m.Studio.Equals(studio, StringComparison.OrdinalIgnoreCase)) &&
				(genre == null || m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) &&
				(!year.HasValue || m.Year == year) &&
				(director == null || m.Director.Equals(director, StringComparison.OrdinalIgnoreCase)) &&
				(actor == null || m.MainActors.Contains(actor, StringComparer.OrdinalIgnoreCase))
			).ToList();
		}


		static public List<Movie> GetMoviesBySize(double maxSize)
		{
			return movies.Where(m => m.Size <= maxSize).ToList();
		}

		static public List<Movie> GetMoviesByDuration(double maxDuration)
		{
			return movies.Where(m => m.Duration <= maxDuration).ToList();
		}

		static public bool IsMovieInCollection(string title)
		{
			return movies.Any(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		}

		static public void Load()
		{
			if (File.Exists(filePath))
			{
				var json = File.ReadAllText(filePath);
				movies = JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
				string moviesstr = "";
				foreach (var movie in movies)
				{
					moviesstr += movie.ToString() + "\n";
				}
				File.WriteAllText("log.txt", moviesstr);
			}
			else
			{
				movies = new List<Movie>();
			}
		}

		static public void Save()
		{
			var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
			File.WriteAllText(filePath, json);
		}
		static public void RemoveDuplicates()
		{
			movies = movies.GroupBy(m => m.Title, StringComparer.OrdinalIgnoreCase)
						   .Select(g => g.First())
						   .ToList();
			Save();
		}
	}
}