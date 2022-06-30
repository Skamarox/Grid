using System.Collections.Generic;
using UnityEngine;

public class ClearGrid
{
    [SerializeField] private Queue<GameObject> Grid = new Queue<GameObject>();

    public void AddObject(GameObject cell) => Grid.Enqueue(cell);

    public void Clear() 
    {
        while(Grid.Count > 0)
        {
            Object.Destroy(Grid.Dequeue());
        }
    }
}
