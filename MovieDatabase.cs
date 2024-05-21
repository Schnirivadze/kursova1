using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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
	public double Size { get; set; } // Size in MB or GB
	public double Duration { get; set; } // Duration in minutes
}

public class MovieDatabase
{
	private List<Movie> movies;
	private string filePath = "movies.json";

	public MovieDatabase()
	{
		Load();
	}

	public void AddMovie(Movie movie)
	{
		movies.Add(movie);
		Save();
	}

	public void RemoveMovie(string title)
	{
		movies.RemoveAll(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
		Save();
	}

	public void UpdateMovie(string title, Movie updatedMovie)
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

	public Movie GetMovie(string title)
	{
		return movies.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
	}

	public List<Movie> SearchMovies(string genre = null, string actor = null, string director = null)
	{
		return movies.Where(m =>
			(genre == null || m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) &&
			(actor == null || m.MainActors.Contains(actor, StringComparer.OrdinalIgnoreCase)) &&
			(director == null || m.Director.Equals(director, StringComparison.OrdinalIgnoreCase))
		).ToList();
	}

	public List<Movie> GetMoviesBySize(double maxSize)
	{
		return movies.Where(m => m.Size <= maxSize).ToList();
	}

	public List<Movie> GetMoviesByDuration(double maxDuration)
	{
		return movies.Where(m => m.Duration <= maxDuration).ToList();
	}

	public bool IsMovieInCollection(string title)
	{
		return movies.Any(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
	}

	private void Load()
	{
		if (File.Exists(filePath))
		{
			var json = File.ReadAllText(filePath);
			movies = JsonConvert.DeserializeObject<List<Movie>>(json) ?? new List<Movie>();
		}
		else
		{
			movies = new List<Movie>();
		}
	}

	private void Save()
	{
		var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
		File.WriteAllText(filePath, json);
		Console.WriteLine("----------------------------------------------------------------------------------------");
		Console.WriteLine(json);
	}
}
