using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DoubleBufferPattern
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RectTransform _rectTransf = default;
        [SerializeField] private Image _image = default;
        [SerializeField] private TextMeshProUGUI _textMesh = default;

        private Grid _grid;

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsWall { get; private set; }

        public void Create(int x, int y, Grid grid)
        {
            _grid = grid;

            X = x;
            Y = y;
            _textMesh.text = $"x {x} \n y {y}";
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_grid == null)
                return;

            _grid.OnCellClicked(X, Y, eventData.button);
        }

        public void ChangeColor(Color color, bool isWall)
        {
            _image.color = color;
            IsWall = isWall;
        }

        public void WriteValue(string value)
        {
            _textMesh.text = $"x {X} \n y {Y} \n v {value}";
        }
    }

}
