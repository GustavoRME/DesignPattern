using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypeObjectPattern
{
    public class RentalCompany : MonoBehaviour
    {
        [SerializeField] private MovieShelf _movieShelf = default;
        [SerializeField] private MoviePlayer _moviePlayer = default;

        private int _index;

        public void TestMovie()
        {
            _moviePlayer.InsertNewMovie(_movieShelf.PickUpMovie(_index));
            _index++;
        }
    }
}
