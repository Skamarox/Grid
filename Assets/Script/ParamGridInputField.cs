using UnityEngine;
using TMPro;

public enum InputFields { Column, Raw };

public class ParamGridInputField : MonoBehaviour
{
    [SerializeField] private InputFields IField;
    private TMP_InputField Field;
    private InputEnum EnumInput;

    private void Start()
    {
        EnumInput = new InputEnum();
        Field = GetComponent<TMP_InputField>();
    }
    
    public void EndInputValue() 
    {
        int value = System.Convert.ToInt32(Field.text);
        EnumInput.SendValue(IField, value);
    }
}

public class InputEnum
{
    private CreateGrid grid;
    private CreateGrid Grid
    {
        get
        {
            if(grid == null)
                grid = Object.FindObjectOfType<CreateGrid>();
            return grid;
        }
    }

    public void SendValue(InputFields type, int value)
    {
        switch(type)
        {
            case InputFields.Column:
                Grid.SetColumn(value);
                break;

            case InputFields.Raw:
                Grid.SetRow(value);
                break;
        }
    }
}
