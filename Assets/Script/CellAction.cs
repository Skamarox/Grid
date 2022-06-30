using System.Collections.Generic;
using UnityEngine;

public class CellAction
{
    public void MixGrid(Stack<IMover> Cells)
    {
        var list = FillList(Cells);
        for (int i = 0; i < list.Count - 1; i++)
        {
            MonoBehaviour monoBehaviour = list[i + 1] as MonoBehaviour;
            list[i].SetTarget(monoBehaviour.transform.position);
        }
        MonoBehaviour lastMono = list[0] as MonoBehaviour;
        list[list.Count - 1].SetTarget(lastMono.transform.position);
    }

    private List<IMover> FillList(Stack<IMover> Cells)
    {
        var list = new List<IMover>();
        var massive = new List<IMover>(Cells.ToArray());
        while (list.Count < massive.Count)
        {
            int random = Random.Range(0, Cells.Count);
            if (list.Contains(massive[random]) == false)
            {
                list.Add(massive[random]);
            }
        }
        return list;
    }
}
