using System.IO;
using UnityEngine;

namespace TypeObjectPattern
{
    public class MovieJsonCreator
    {
        private static MovieJsonCreator _instance = new MovieJsonCreator();
        public static MovieJsonCreator Instance => _instance;

        private static readonly string _path = File.ReadAllText(Application.dataPath + "/Patterns/07-TypeObject/Json/MovieJson.json");

        public VideoTapeAndMovieJsonArray TakeFromJson()
        {
            return JsonUtility.FromJson<VideoTapeAndMovieJsonArray>(_path);
        }
    }
}
