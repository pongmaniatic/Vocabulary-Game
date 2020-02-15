using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public string WordSide1 = "Empty";
    public string WordSide2 = "Empty";
    public int Checks = 0;
    public int Position = 0;
    public bool CurrentSide = true;
    public TextMeshProUGUI Word;
    public GameObject Master2;
    public GameObject GameManager;
    public GameManagerScript GameManagerScript;
    public Master_Script MasterScript;

    public Sprite Card;
    public Sprite Card1Check;
    public Sprite Card2Check;

    public Sprite CardSelected;
    public Sprite CardSelected1Check;
    public Sprite CardSelected2Check;

    void Awake() // Finds the master object and its script
    {
        MasterScript = Master_Script.MasterObject;
        GameManager = GameObject.Find("GameManager");
        GameManagerScript = GameManager.GetComponent<GameManagerScript>();
    }

    void Start()
    {
        if (Position == 1)
        {
            transform.position = new Vector3(-3.65f, 2.8f, 0);
        }
        if (Position == 2)
        {
            transform.position = new Vector3(0, 2.8f, 0);
        }
        if (Position == 3)
        {
            transform.position = new Vector3(3.65f, 2.8f, 0);
        }
        if (Position == 4)
        {
            transform.position = new Vector3(-3.65f, 0.58f, 0);
        }
        if (Position == 5)
        {
            transform.position = new Vector3(0, 0.58f, 0);
        }
        if (Position == 6)
        {
            transform.position = new Vector3(3.65f, 0.58f, 0);
        }
        if (Position == 7)
        {
            transform.position = new Vector3(-3.65f, -1.64f, 0);
        }
        if (Position == 8)
        {
            transform.position = new Vector3(0, -1.64f, 0);
        }
        if (Position == 9)
        {
            transform.position = new Vector3(3.65f, -1.64f, 0);
        }
        Word.text = WordSide2;
    }

    public void Update()
    {
        if (Checks == 0)
        {
            if (GameManagerScript.SelectedCard == Position)
            {
                this.gameObject.GetComponent<Image>().sprite = CardSelected;
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = Card;
            }
        }
        if (Checks == 1)
        {
            if (GameManagerScript.SelectedCard == Position)
            {
                this.gameObject.GetComponent<Image>().sprite = CardSelected1Check;
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = Card1Check;
            }
        }
        if (Checks == 2)
        {
            if (GameManagerScript.SelectedCard == Position)
            {
                this.gameObject.GetComponent<Image>().sprite = CardSelected2Check;
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = Card2Check;
            }
        }

        if (GameManagerScript.SelectedCard == Position && GameManagerScript.CorrectCheck == 1)
        {
            GameManagerScript.CorrectCheck = 0;
            if (Checks < 2)
            {
                Checks += 1;
            }
        }
        if (GameManagerScript.SelectedCard == Position && GameManagerScript.CorrectCheck == 2)
        {
            GameManagerScript.CorrectCheck = 0;
        }

    }

    public void Selected()
    {

        GameManagerScript.SelectedCard = Position;
        GameManagerScript.word1 = WordSide1;
        GameManagerScript.word2 = WordSide2;
        GameManagerScript.FirstSelect = false;
    }
}
