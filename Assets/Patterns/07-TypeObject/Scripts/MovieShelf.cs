using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    public class MovieShelf : MonoBehaviour
    {
        [Serializable]
        private class MovieSection
        {
            [SerializeField] private VideoTapeData _videoTape = default;
            [SerializeField] private string[] _moviesNames = default;

            public MovieSection(VideoTapeData videoTape, string[] movieNames)
            {
                _videoTape = videoTape;
                _moviesNames = movieNames;
            }

            public VideoTapeData VideoTape => _videoTape;
            public string[] MovieNames => _moviesNames;
        }

        [SerializeField] private List<MovieSection> _movieSections = default;

        private Movie[] _movies = new Movie[0];
        private Movie _emptyMovie;

        private void Awake()
        {
            _emptyMovie = VideoTapeData.CreateEmptyMovie();

            LoadMovies();
            CreateMovieShelf();
        }

        public Movie PickUpMovie(int index)
        {
            if(_movies.Length == 0 || index == _movies.Length)
            {
                return _emptyMovie;
            }

            return _movies[index];
        }

        public Movie PickUpMovie(string name)
        {
            if(_movies.Length == 0)
            {
                return _emptyMovie;
            }

            for (int i = 0; i < _movies.Length; i++)
            {
                if (_movies[i].MovieName.Contains(name))
                    return _movies[i];
            }

            return _emptyMovie;
        }

        private void CreateMovieShelf()
        {
            List<Movie> moviesList = new List<Movie>();
            foreach (var session in _movieSections)
            {
                foreach (var movieName in session.MovieNames)
                {
                    moviesList.Add(session.VideoTape.CreateMovie(movieName));
                }
            }

            _movies = moviesList.ToArray();
        }

        private void LoadMovies()
        {
            VideoTapeAndMovieJsonArray moviesJson = MovieJsonCreator.Instance.TakeFromJson();
            for (int i = 0; i < moviesJson.array.Length; i++)
            {
                VideoTapeData videoTape = ScriptableObject.CreateInstance<VideoTapeData>();
                videoTape.SetValues(moviesJson.array[i].price, moviesJson.array[i].duration, moviesJson.array[i].seasons);
                _movieSections.Add(new MovieSection(videoTape, moviesJson.array[i].movies));
            }
        }
    }
}
