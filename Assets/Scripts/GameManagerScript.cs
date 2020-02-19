using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManagerScript : MonoBehaviour
{
    //Debug.Log(" ");
    public int SelectedCard = 0;
    public string Word1;
    public string Word2;
    public string HintWord = "";
    public string InputWord;

    public TextMeshProUGUI HintWriter;
    public TMP_InputField TextBox;
    public Button Button;
    public Button HiddenButton;
    public bool FirstSelect = false;

    public int CorrectCheck = 0;
    public int CoolDown;

    public int NumberOfCardsActive = 9;

    public Action TestDelegate;

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckWord();
        }
        if (SelectedCard != 0)
        {
            Word1 = Word1.ToLower();
            Word2 = Word2.ToLower();
            InputWord = TextBox.text;
            InputWord = InputWord.ToLower();
            InputWord = InputWord.Trim();
            if (FirstSelect == false)
            {
                TextBox.gameObject.SetActive(true);
                HintWriter.gameObject.SetActive(true);
                Button.gameObject.SetActive(true);

                TextBox.text = "";
                int HintLenght = Word1.Length;
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
        if (TestDelegate != null)
        {
            TestDelegate();
        }
        TextBox.gameObject.SetActive(false);
        HintWriter.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);
        if (InputWord == Word1)
        {
            TextBox.text = "";
            CorrectCheck = 1;
        }
        else
        {
            TextBox.text = "";
            CorrectCheck = 2;
        }
    }
    public void HiddenButtonActivate()
    {
        HiddenButton.gameObject.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu_principal");
    }

}
