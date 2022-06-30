using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CreateGrid : MonoBehaviour
{
    private Stack<IMover> Cells;
    private int Column;
    private int Row;
    [SerializeField] private Transform parent;
    [SerializeField] private TMP_Text Txt;
    [SerializeField] private GameObject Error;
    private UIMixGrid UIMix;
    private UIGenerateGrid UIGenerate;
    private ClearGrid GridClear;

    private void Start()
    {
        GridClear = new ClearGrid();
        UIMix = FindObjectOfType<UIMixGrid>();
        UIGenerate = FindObjectOfType<UIGenerateGrid>();
    }

    public void SetColumn(int Column) => this.Column = Column;
    public void SetRow(int Row) => this.Row = Row;

    public void Generate()
    {
        if (Column <= 0 || Row <= 0)
        {
            if (Error.activeInHierarchy == false)
            {
                Error.SetActive(true);
                Invoke("HideErrorMEssage", 2f);
            }
            return;
        }
        if (parent.childCount > 0)
            GridClear.Clear();

        Cells = new Stack<IMover>();

        Vector2 size = SetSize();
        Txt.rectTransform.sizeDelta = size;

        float sizeX = size.x / 2;
        float sizeY = size.y / 2;
        float offsetX = Column % 2 == 0 ? sizeX : 0;
        float offsetY = Row % 2 == 0 ? sizeY : 0;

        for (int i = 1; i < Column + 1; i++)
        {
            float factorX = i % 2 == 0 ? i * sizeX : (i - 1) * (-sizeX);
            for (int j = 1; j < Row + 1; j++)
            {
                TMP_Text text = Instantiate(Txt, parent);
                text.name = i + "_" + j;
                text.text = text.name;
                float factorY = j % 2 == 0 ? j * sizeY : (j - 1) * (-sizeY);
                text.rectTransform.anchoredPosition = new Vector2(factorX - offsetX, factorY - offsetY);
                Cells.Push(text.GetComponent<CellMove>());
                UIGenerate.AddText(text);
                GridClear.AddObject(text.gameObject);
            }
        }
        UIMix.SetCells(Cells);
        UIGenerate.Generate();
    }

    private Vector2 SetSize() 
    {
        Vector2 v2 = parent.GetComponent<RectTransform>().sizeDelta;
        return new Vector2(v2.x / Column, v2.y / Row);
    }

    private void HideErrorMEssage()
    {
        Error.SetActive(false);
    }
}
