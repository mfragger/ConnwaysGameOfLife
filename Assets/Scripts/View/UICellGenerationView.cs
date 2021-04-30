using System.Collections.Generic;
using UnityEngine;

namespace ConnwaysGameOfLife.View
{
    public class UICellGenerationView : MonoBehaviour
    {
        public void GenerateGrid(List<List<GameObject>> Cells, GameObject cell, int row, int col, float gap, Cinemachine.CinemachineTargetGroup CinemachineTargetGroup)
        {
            if (Cells.Count > 0)
            {
                for (int i = 0; i < Cells.Count; i++)
                {
                    for (int j = 0; j < Cells[i].Count; j++)
                    {
                        Cells[i][j].SetActive(false);
                        CinemachineTargetGroup.RemoveMember(Cells[i][j].GetComponent<Transform>());
                    }
                }
            }

            for (int i = 0; i < row; i++)
            {
                var subList = new List<GameObject>();
                for (int j = 0; j < col; j++)
                {
                    if (i < Cells.Count && j < Cells[i].Count)
                    {
                        Cells[i][j].SetActive(true);
                        CinemachineTargetGroup.AddMember(Cells[i][j].GetComponent<Transform>(), 1, 0);
                    }
                    else
                    {
                        var go = Instantiate(cell, new Vector3(i * gap, j * gap, 0), Quaternion.identity);
                        go.name = $"{i},{j}";
                        CinemachineTargetGroup.AddMember(go.GetComponent<Transform>(), 1, 0);
                        if (i >= Cells.Count)
                        {
                            subList.Add(go);
                        }
                        else
                        {
                            Cells[i].Add(go);
                        }
                    }
                }
                if (subList.Count > 0)
                {
                    Cells.Add(subList);
                }
            }
        }
    }
}