using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameField
{
    public class GridSelectionManager : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private List<GameFieldCell> _selectedCells = new List<GameFieldCell>();
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var cell = FindCellByRaycast();
                if (cell != null)
                {
                    cell.Select();
                    _selectedCells.Add(cell);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                foreach (var cell in _selectedCells)
                {
                    cell.Deselect();
                }
                _selectedCells.Clear();
            }
        }

        private GameFieldCell FindCellByRaycast()
        {
            var hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                var cell = hit.transform.GetComponent<GameFieldCell>();
                return cell;
            }
            else
            {
                return null;
            }
        }
    }
}