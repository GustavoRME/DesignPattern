using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DoubleBufferPattern
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private Cell _cellPrefab = default;
        [SerializeField] private RectTransform _rectTransf = default;
        [SerializeField] private CellularAutomataWater2D _cellularAutomata = default;

        [Header("Colors")]
        [SerializeField] private Color _wallColor = Color.black;
        [SerializeField] private Color _waterCollor = Color.blue;
        [SerializeField] private Color _emptyColor = Color.white;

        private Cell[,] _cells;

        public void DrawGrid(int gridSize)
        {
            if (_cells != null)
                ClearGrid();

            _cells = new Cell[gridSize, gridSize];
            for (int y = 0; y < gridSize; y++)
            {
                for (int x = 0; x < gridSize; x++)
                {
                    Cell cell = Instantiate(_cellPrefab, _rectTransf);
                    cell.Create(x, y, this);

                    _cells[x, y] = cell;
                }
            }
        }

        public void SetCell(int x, int y, float value, bool isWater)
        {
            _cells[x, y].WriteValue(value.ToString("F1"));

            //Only change color if isn't a wall
            if (_cells[x, y].IsWall)
                return;

            Color color = isWater ? _waterCollor : _emptyColor;
            _cells[x, y].ChangeColor(color, false);
        }

        public void OnCellClicked(int x, int y, PointerEventData.InputButton inputButton)
        {
            if(inputButton == PointerEventData.InputButton.Left)
            {
                //Move water
            }
            else if(inputButton == PointerEventData.InputButton.Right)
            {
                //Create/Remove wall

                bool isWall = !_cells[x, y].IsWall;
                Color color = isWall ? _wallColor : _emptyColor;

                _cellularAutomata.SetWall(x, y, isWall);

                _cells[x, y].ChangeColor(color, isWall);
            }
        }

        private void ClearGrid()
        {
            for (int y = 0; y < _cells.GetLength(0); y++)
            {
                for (int x = 0; x < _cells.GetLength(1); x++)
                {
                    Destroy(_cells[x, y]);
                }
            }
            _cells = null;
        }
    }

}
