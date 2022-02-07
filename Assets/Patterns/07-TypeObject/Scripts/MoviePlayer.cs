using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    public class MoviePlayer : MonoBehaviour
    {
        [SerializeField] private Movie _currentMovie = default;
        [SerializeField] private MoviePlayerUI _movieUI = default;

        private bool _isPlaying;
        public bool IsPlaying => _isPlaying;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            bool isPlaying = _currentMovie.UpdateMe();
            _movieUI.WriteTime(_currentMovie.CurrentTime);
            
            _isPlaying = isPlaying;
            enabled = isPlaying;
        }

        public void InsertNewMovie(Movie movie)
        {
            if (movie == null)
                return;

            if (_currentMovie != null)
                _currentMovie.Stop();

            _currentMovie = movie;
            _movieUI.WriteMovieName(_currentMovie.MovieName);
        }

        public void Play()
        {
            if (_currentMovie == null)
                return;

            _currentMovie.Play();
            _movieUI.WriteMovieName(_currentMovie.MovieName);
            _isPlaying = true;
            enabled = true;
        }

        public void Pause()
        {
            enabled = false;
        }

        public void Stop()
        {
            if (_currentMovie == null)
                return;

            _currentMovie.Stop();
            _movieUI.WriteTime(_currentMovie.CurrentTime);
            _isPlaying = false;
            enabled = false;
        }

        public void FastForward()
        {
            if (_currentMovie == null)
                return;

            _currentMovie.FastForward();
        }

        public void FastBack()
        {
            if (_currentMovie == null)
                return;

            _currentMovie.FastBack();
        }
    }

}
