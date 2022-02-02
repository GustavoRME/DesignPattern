using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    public class MoviePlayer : MonoBehaviour
    {
        [SerializeField] private Movie _currentMovie = default;
        [SerializeField] private MoviePlayerUI _movieUI = default;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            enabled = _currentMovie.UpdateMe();
            _movieUI.WriteTime(_currentMovie.CurrentTime);
        }

        public void Play()
        {
            _currentMovie.Play();
            enabled = true;
        }

        public void Pause()
        {
            enabled = false;
        }

        public void Stop()
        {
            _currentMovie.Stop();
            _movieUI.WriteTime(_currentMovie.CurrentTime);
            enabled = false;
        }

        public void FastForward()
        {
            _currentMovie.FastForward();
        }

        public void FastBack()
        {
            _currentMovie.FastBack();
        }
    }

}
