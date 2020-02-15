using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public int SelectedCard = 0;
    public string word1;
    public string word2;
    public string HintWord = "";
    public string InputWord;

    public TextMeshProUGUI HintWriter;
    public TMP_InputField TextBox;
    public bool FirstSelect = false;

    public int CorrectCheck = 0;


    void Update()
    {
        if (SelectedCard != 0)
        {
            word1 = word1.ToLower();
            word2 = word2.ToLower();
            InputWord = TextBox.text;
            InputWord = InputWord.ToLower();
            if (FirstSelect == false)
            {
                TextBox.text = "";
                int HintLenght = word1.Length;
                HintWord = "";
                for (int i = 0; i < HintLenght; i++)
                {
                    HintWord += "_ ";
                }
                HintWriter.text = HintWord;
                FirstSelect = true;
            }
        }
        
    }

    public void CheckWord()
    {
        if (InputWord == word1)
        {
            CorrectCheck = 1;
            Debug.Log("");
            Debug.Log("");
            Debug.Log("");
            Debug.Log("Mycket Bra");
        }
        else
        {
            CorrectCheck = 2;
            Debug.Log("");
            Debug.Log("");
            Debug.Log("");
            Debug.Log("Mycket inte Bra");
        }
    }
}
