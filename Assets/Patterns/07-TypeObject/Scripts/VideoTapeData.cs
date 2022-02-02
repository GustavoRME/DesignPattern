using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    [CreateAssetMenu(fileName = "VideoTape", menuName = "TypeObject/VideoTape")]
    public class VideoTapeData : ScriptableObject
    {
        [SerializeField] private string _name = "";
        [SerializeField] private float _price = 0.0f;
        [SerializeField] private float _duration = 0.0f;
        [SerializeField] private float _sessions = 0.0f;

        public string Name => _name;
        public float Price => _price;
        public float Duration => _duration;
        public float Sessions => _sessions;
    }
}
