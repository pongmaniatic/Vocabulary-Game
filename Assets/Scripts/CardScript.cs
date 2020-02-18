using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardScript : MonoBehaviour
{
    //Debug.Log(" ");
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
    public Sprite CardSelected1CheckCorrect;
    public Sprite CardSelected2CheckCorrect;
    public GameObject GameMenubar;
    public TMP_InputField TextBox;
    public bool VictoryCheck = false;

    public int CoolDownTime = 0;
    public bool CoolDown = false;

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
        if (GameMenubar == null)
        {
            GameMenubar = GameObject.FindGameObjectWithTag("GameMenu");
            
        }
        if (GameMenubar != null && TextBox == null)
        {
            TextBox = GameMenubar.GetComponent<TMP_InputField>();
        }


        // This is for showing the right sprite
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
        } // No check
        if (Checks == 1)
        {
            if (GameManagerScript.SelectedCard == Position)
            {
                if (VictoryCheck == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = CardSelected1CheckCorrect;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = CardSelected1Check;
                }
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = Card1Check;
            }
        } // One check
        if (Checks == 2)
        {
            if (GameManagerScript.SelectedCard == Position)
            {

                if (VictoryCheck == true)
                {
                    this.gameObject.GetComponent<Image>().sprite = CardSelected2CheckCorrect;
                }
                else
                {
                    this.gameObject.GetComponent<Image>().sprite = CardSelected2Check;
                }
                
            }
            else
            {
                this.gameObject.GetComponent<Image>().sprite = Card2Check;
            }
        } // Two checks

        // This is for adding new checks
        if (GameManagerScript.SelectedCard == Position && GameManagerScript.CorrectCheck == 1)
        {
            GameManagerScript.CorrectCheck = 0;
            if (Checks < 2)
            {
                Checks += 1;
                VictoryCheck = true;
            }
        }
        if (GameManagerScript.SelectedCard == Position && GameManagerScript.CorrectCheck == 2)
        {
            GameManagerScript.CorrectCheck = 0;
            Word.text = WordSide1;
            CoolDownTime = 1;
            CoolDown = true;
        }

        if (VictoryCheck == true && GameManagerScript.SelectedCard != Position)
        {
            VictoryCheck = false;
            transform.position = new Vector3(-9f, 7f, 0);
            GameManagerScript.NumberOfCardsActive -= 1;
        }
        if (VictoryCheck == true)
        {
            Word.text = WordSide1;
            if (GameManagerScript.NumberOfCardsActive < 2)
            {
                GameManagerScript.HiddenButton();
                transform.position = new Vector3(-9f, 7f, 0);
                GameManagerScript.NumberOfCardsActive -= 1;
            }
        }

        if (GameManagerScript.SelectedCard != Position && GameManagerScript.CorrectCheck == 0)
        {
            Word.text = WordSide2;
        }
        if (CoolDownTime == 0)
        {
            CoolDown = false;
        }
        if (CoolDown == true)
        {
            //add code later  
        }
    }
    public void Selected()
    {
        //EventSystem.current.SetSelectedGameObject(null);
        //EventSystem.current.SetSelectedGameObject(TextBox.gameObject);
        GameManagerScript.SelectedCard = Position;
        GameManagerScript.word1 = WordSide1;
        GameManagerScript.word2 = WordSide2;
        GameManagerScript.FirstSelect = false;
        //TextBox.Select();
        StartCoroutine(SelectTextField());
    }
    private IEnumerator SelectTextField()
    {
        yield return new WaitForSeconds(0.1f);
        TextBox.Select();
    }
}
