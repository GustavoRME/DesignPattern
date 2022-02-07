using System;

namespace TypeObjectPattern
{
    [Serializable]
    public class VideoTapeAndMovieJson
    {
        public float price;
        public float duration;
        public int seasons;
        public string[] movies;
    }

    [Serializable]
    public class VideoTapeAndMovieJsonArray
    {
        public VideoTapeAndMovieJson[] array;
    }
}