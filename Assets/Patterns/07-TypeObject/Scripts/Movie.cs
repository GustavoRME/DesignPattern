using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern 
{
    public class Movie
    {
        private VideoTapeData _data = default;

        private float _playSpeed = 1.0f;
        private float _maxSpeed = 3.0f;
        private float _currentTime;
        private bool _isFasting;
        private bool _isFowarding;

        private string _movieName;

        public float CurrentTime => _currentTime;
        public string MovieName => _movieName;

        public Movie(VideoTapeData videoTape, string name)
        {
            _data = videoTape;
            _movieName = name;
        }

        /// <summary>
        /// </summary>
        /// <returns> return true if yet has movie to playing</returns>
        public bool UpdateMe()
        {
            _currentTime += Time.deltaTime * _playSpeed;

            if(_isFasting)
            {
                _playSpeed = _isFowarding ?
                    _playSpeed + Time.deltaTime :
                    _playSpeed - Time.deltaTime;

                if (Mathf.Abs(_playSpeed) >= _maxSpeed)
                {
                    _playSpeed = _isFowarding ? _maxSpeed : -_maxSpeed;
                    _isFasting = false;
                }
            }

            if (_currentTime >= _data.Duration) 
                _currentTime = _data.Duration;
            else if (_currentTime < .0f) 
                _currentTime = 0.0f;

            return _currentTime < _data.Duration && _currentTime > 0.0f;
        }

        public void Play()
        {
            _playSpeed = 1.0f;
            _isFasting = false;

            if (_currentTime >= _data.Duration)
                _currentTime = 0.0f;
        }

        public void Stop()
        {
            _currentTime = 0.0f;
        }

        public void ForwardSeconds(float seconds)
        {
            float toSkip = _currentTime + seconds;
            _currentTime = toSkip >= _data.Duration ? _data.Duration : toSkip;
        }

        public void BackSeconds(float seconds)
        {
            float toSkip = _currentTime - seconds;
            _currentTime = toSkip <= .0f ? .0f : toSkip;
        }

        public void FastForward()
        {
            _isFasting = true;
            _isFowarding = true;
            _playSpeed = 1.0f;
        }

        public void FastBack()
        {
            _isFasting = true;
            _isFowarding = false;
            _playSpeed = -1.0f;
        }

        public void SkipToEnd()
        {
            _currentTime = _data.Duration;
        }

        public void SkipToStart()
        {
            _currentTime = 0.0f;
        }
    }

}
