using System.Collections.Generic;
using UnityEngine;

public class UIMixGrid : MonoBehaviour
{
    private CellAction Action = new CellAction();
    private Stack<IMover> Cells;

    public void SetCells(Stack<IMover> Cells) => this.Cells = new Stack<IMover>(Cells);

    public void Mix()
    {
        Action.MixGrid(new Stack<IMover>(Cells));
    }
}
