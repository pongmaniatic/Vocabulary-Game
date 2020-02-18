using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //Debug.Log(" ");
    public int SelectedCard = 0;
    public string word1;
    public string word2;
    public string HintWord = "";
    public string InputWord;

    public TextMeshProUGUI HintWriter;
    public TMP_InputField textBox;
    public Button button;
    public Button hiddenButton;
    public bool FirstSelect = false;

    public int CorrectCheck = 0;

    public int NumberOfCardsActive = 9;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckWord();
        }
        if (SelectedCard != 0)
        {
            word1 = word1.ToLower();
            word2 = word2.ToLower();
            InputWord = textBox.text;
            InputWord = InputWord.ToLower();
            if (FirstSelect == false)
            {
                textBox.gameObject.SetActive(true);
                HintWriter.gameObject.SetActive(true);
                button.gameObject.SetActive(true);

                textBox.text = "";
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
        textBox.gameObject.SetActive(false);
        HintWriter.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        if (InputWord == word1)
        {
            textBox.text = "";
            CorrectCheck = 1;
        }
        else
        {
            textBox.text = "";
            CorrectCheck = 2;
        }
    }
    public void HiddenButton()
    {
        hiddenButton.gameObject.SetActive(true);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu_principal");
    }
}
