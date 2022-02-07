using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    [CreateAssetMenu(fileName = "VideoTape", menuName = "TypeObject/VideoTape")]
    public class VideoTapeData : ScriptableObject
    {
        [SerializeField] private float _price = 0.0f;
        [SerializeField] private float _duration = 0.0f;
        [SerializeField] private int _seasons = 0;

        public float Price => _price;
        public float Duration => _duration;
        public int Seasons => _seasons;

        public static Movie CreateEmptyMovie()
        {
            return CreateInstance<VideoTapeData>().CreateMovie("");
        }

        public Movie CreateMovie(string movieName)
        {
            return new Movie(this, movieName);
        }

        public void SetValues(float price, float duration, int seasons)
        {
            _price = price;
            _duration = duration;
            _seasons = seasons;
        }
    }
}
