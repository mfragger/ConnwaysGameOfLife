
using System.Collections.Generic;
using UnityEngine;

namespace ConnwaysGameOfLife.Model
{
    public class CellGridModel : MonoBehaviour
    {
        public List<List<GameObject>> Cells = new List<List<GameObject>>();
        public List<List<bool>> StateList = new List<List<bool>>();

        public Color BGColor = Color.white;
        public Color BoxColor = Color.black;

        [SerializeField] private GameObject _Cell;
        public GameObject Cell { get => _Cell; }
        [SerializeField] private int _row;
        public int Row { get => _row > -1 ? _row : 0; set => _row = value; }

        [SerializeField] private int _col;

        public int Col { get => _col > -1 ? _col : 0; set => _col = value; }

        [SerializeField] private float _gap;

        public float gap { get => _gap; }

        public void NeighborCount()
        {
            for (int r = 0; r < Cells.Count; r++)
            {
                for (int c = 0; c < Cells[r].Count; c++)
                {
                    int neighbor = 0;
                    //up
                    if (c + 1 < Cells[r].Count)
                    {
                        if (Cells[r][c + 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //down
                    if (c - 1 >= 0)
                    {
                        if (Cells[r][c - 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //left
                    if (r - 1 >= 0)
                    {
                        if (Cells[r - 1][c].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //right
                    if (r + 1 < Cells.Count)
                    {
                        if (Cells[r + 1][c].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //up - left
                    if (c + 1 < Cells[r].Count && r - 1 >= 0)
                    {
                        if (Cells[r - 1][c + 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //up - right
                    if (c + 1 < Cells[r].Count && r + 1 < Cells.Count)
                    {
                        if (Cells[r + 1][c + 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //down - left
                    if (c - 1 >= 0 && r - 1 >= 0)
                    {
                        if (Cells[r - 1][c - 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    //down - right
                    if (c - 1 >= 0 && r + 1 < Cells.Count)
                    {
                        if (Cells[r + 1][c - 1].GetComponent<CellModel>().IsAlive)
                        {
                            neighbor++;
                        }
                    }
                    Cells[r][c].GetComponent<CellModel>().NumNeighbors = neighbor;
                }
            }
        }
    }
}