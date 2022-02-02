using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TypeObjectPattern 
{
    public class MoviePlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _movieName = default;
        [SerializeField] private TextMeshProUGUI _movieCurrentTime = default;

        public void WriteMovieName(string movieName)
        {
            _movieName.text = movieName;
        }

        public void WriteTime(float currentTime)
        {
            _movieCurrentTime.text = $"Time: {currentTime : 0#.##0}";
        }
    }
}

