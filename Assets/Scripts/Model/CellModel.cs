using UnityEngine;

namespace ConnwaysGameOfLife.Model
{
    public class CellModel : MonoBehaviour
    {
        [SerializeField] private bool _IsAlive;
        public bool IsAlive { get => _IsAlive; set => _IsAlive = value; }
        public int NumNeighbors;

        public bool RandomizeState()
        {
            IsAlive = Random.Range(0, 2) == 1;
            return IsAlive;
        }

        public bool WouldBeAlive()
        {
            //Rules 
            //Any live cell with fewer than two live neighbours dies, as if by underpopulation
            //Cell.IsAlive && Cell.NumNeighbors < 2 => !Cell.IsAlive
            if (IsAlive && NumNeighbors < 2)
            {
                IsAlive = false;
            }
            //Any live cell with two or three live neighbours lives on to the next generation.
            //Cell.IsAlive && Cell.NumNeighbors > 2 || Cell.NumNeighbors <=3 => Cell.IsAlive
            else if (IsAlive && (NumNeighbors == 2 || NumNeighbors == 3))
            {
                IsAlive = true;
            }
            //Any live cell with more than three live neighbours dies, as if by overpopulation.
            //Cell.IsAlive && Cell.NumNeighbors > 3 => !Cell.IsAlive
            else if (IsAlive && NumNeighbors > 3)
            {
                IsAlive = false;
            }
            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            //!Cell.IsAlive && Cell.NumNeighbors == 3 => Cell.IsAlive 
            else if (!IsAlive && NumNeighbors == 3)
            {
                IsAlive = true;
            }
            return IsAlive;
        }
    }
}