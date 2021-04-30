using System.Collections.Generic;
using UnityEngine;

namespace ConnwaysGameOfLife.View
{
    public class CellChangeView : MonoBehaviour
    {
        public void ChangeSingleCellState(GameObject Cell, bool newState, Color BGColor, Color BoxColor)
        {
            Cell.GetComponent<SpriteRenderer>().color = newState ? BoxColor : BGColor;
        }
    }
}