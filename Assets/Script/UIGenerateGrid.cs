using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGenerateGrid : MonoBehaviour
{
    private string[] ABC = new string[]
    {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    private Stack<TMP_Text> Text = new Stack<TMP_Text>();

    public void AddText(TMP_Text Text)
    {
        this.Text.Push(Text);
    }

    public void Generate() 
    {
        foreach(TMP_Text text in this.Text)
        {
            int random = Random.Range(0, ABC.Length);
            text.text = ABC[random];
        }
    }
}
