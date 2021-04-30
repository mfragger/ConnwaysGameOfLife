using UnityEngine;
using ConnwaysGameOfLife.View;
using ConnwaysGameOfLife.Model;
using TMPro;
using System.Collections.Generic;

namespace ConnwaysGameOfLife.Controller
{
    public class ManagerController : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] private UICellGenerationView UICellGenerationView;
        [SerializeField] private CellChangeView CellChangeView;
        [Header("Model")]
        [SerializeField] private CellGridModel CellGridModel;

        [Header("Misc")]
        [SerializeField] private Cinemachine.CinemachineTargetGroup CinemachineTargetGroup;
        private bool IsPlay;

        private float SlowMode = 0;
        private float Timer;

        public void RowOnChange(TMP_InputField inputField)
        {
            if (int.TryParse(inputField.text, out var result))
            {
                SetRow(result);
            }
        }
        public void SetRow(int row)
        {
            CellGridModel.Row = row;
            UICellGenerationView.GenerateGrid(CellGridModel.Cells, CellGridModel.Cell, CellGridModel.Row, CellGridModel.Col, CellGridModel.gap, CinemachineTargetGroup);
        }
        public void ColOnChange(TMP_InputField inputField)
        {
            if (int.TryParse(inputField.text, out var result))
            {
                SetCol(result);
            }
        }

        public void SetCol(int col)
        {
            CellGridModel.Col = col;
            UICellGenerationView.GenerateGrid(CellGridModel.Cells, CellGridModel.Cell, CellGridModel.Row, CellGridModel.Col, CellGridModel.gap, CinemachineTargetGroup);
        }

        public void PressPlay()
        {
            if (CellGridModel.Row > 0 && CellGridModel.Col > 0)
            {
                Randomize();
                IsPlay = true;
            }
        }

        private void Randomize()
        {
            for (int r = 0; r < CellGridModel.Cells.Count; r++)
            {
                for (int c = 0; c < CellGridModel.Cells[r].Count; c++)
                {
                    var result = CellGridModel.Cells[r][c].GetComponent<CellModel>().RandomizeState();
                    CellChangeView.ChangeSingleCellState(CellGridModel.Cells[r][c], result, CellGridModel.BGColor, CellGridModel.BoxColor);
                }
            }
        }

        public void ChangeSpeed(TMP_InputField inputField)
        {
            if (float.TryParse(inputField.text, out var result))
            {
                SlowMode = result;
            }
        }


        public void ChangeBGColor(TMP_Dropdown dropdown)
        {
            switch (dropdown.options[dropdown.value].text)
            {
                case "Black":
                    {
                        CellGridModel.BGColor = Color.black;
                        break;
                    }
                case "White":
                    {
                        CellGridModel.BGColor = Color.white;
                        break;
                    }
                case "Red":
                    {
                        CellGridModel.BGColor = Color.red;
                        break;
                    }
                case "Yellow":
                    {
                        CellGridModel.BGColor = Color.yellow;
                        break;
                    }
                case "Blue":
                    {
                        CellGridModel.BGColor = Color.blue;
                        break;
                    }
            }
        }
        public void ChangeBoxColor(TMP_Dropdown dropdown)
        {
            switch (dropdown.options[dropdown.value].text)
            {
                case "Black":
                    {
                        CellGridModel.BoxColor = Color.black;
                        break;
                    }
                case "White":
                    {
                        CellGridModel.BoxColor = Color.white;
                        break;
                    }
                case "Red":
                    {
                        CellGridModel.BoxColor = Color.red;
                        break;
                    }
                case "Yellow":
                    {
                        CellGridModel.BoxColor = Color.yellow;
                        break;
                    }
                case "Blue":
                    {
                        CellGridModel.BoxColor = Color.blue;
                        break;
                    }
            }
        }

        private void Update()
        {
            ChangeCellColorOnMouseClick();
            if (Timer >= SlowMode)
            {
                Timer = 0;
                GameOfLife();
            }
            else
            {
                Timer += Time.deltaTime;
            }
        }

        private void GameOfLife()
        {
            if (IsPlay)
            {
                CellGridModel.NeighborCount();
                PerformAliveOrDead();
            }
        }

        public void PerformAliveOrDead()
        {
            for (int r = 0; r < CellGridModel.Cells.Count; r++)
            {
                for (int c = 0; c < CellGridModel.Cells[r].Count; c++)
                {
                    var result = CellGridModel.Cells[r][c].GetComponent<CellModel>().WouldBeAlive();
                    CellChangeView.ChangeSingleCellState(CellGridModel.Cells[r][c], result, CellGridModel.BGColor, CellGridModel.BoxColor);
                }
            }
        }

        private void ChangeCellColorOnMouseClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10;

                Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);

                RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

                if (hit)
                {
                    var CM = hit.collider.GetComponent<CellModel>();
                    CM.IsAlive = !CM.IsAlive;
                    var cell = hit.collider.gameObject;
                    CellChangeView.ChangeSingleCellState(cell, CM.IsAlive, CellGridModel.BGColor, CellGridModel.BoxColor);
                }
            }
        }
    }
}