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
    public TextMeshProUGUI CardText;
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
    public Sprite Cardlocked;
    public GameObject GameMenubar;
    [SerializeField] private TMP_InputField TextBox;
    public bool VictoryCheck = false;

    public bool CardCoolDownActivated = false;


    void Awake() //(cleaned) Finds the master object and its script 
    {
        MasterScript = Master_Script.MasterObject;
        GameManager = GameObject.Find("GameManager");
        GameManagerScript = GameManager.GetComponent<GameManagerScript>();
    }
    void Start()
    {
        PlaceCardsOnScreen(Position); //position the card to its right spot
        CardText.text = WordSide2; //
        GameManagerScript.TestDelegate += UnlockAllCards;
    }

    public void UnlockAllCards() // This is a delegate that unlocks all cards in screen.
    {
        CardCoolDownActivated = false;
    }
    public void PlaceCardsOnScreen(int CardPosition) // This Function asked what position ID the card has and moves the card to the acording position.
    {
        if (CardPosition == 1)
        {
            transform.position = new Vector3(-3.65f, 2.8f, 0);
        }
        if (CardPosition == 2)
        {
            transform.position = new Vector3(0, 2.8f, 0);
        }
        if (CardPosition == 3)
        {
            transform.position = new Vector3(3.65f, 2.8f, 0);
        }
        if (CardPosition == 4)
        {
            transform.position = new Vector3(-3.65f, 0.58f, 0);
        }
        if (CardPosition == 5)
        {
            transform.position = new Vector3(0, 0.58f, 0);
        }
        if (CardPosition == 6)
        {
            transform.position = new Vector3(3.65f, 0.58f, 0);
        }
        if (CardPosition == 7)
        {
            transform.position = new Vector3(-3.65f, -1.64f, 0);
        }
        if (CardPosition == 8)
        {
            transform.position = new Vector3(0, -1.64f, 0);
        }
        if (CardPosition == 9)
        {
            transform.position = new Vector3(3.65f, -1.64f, 0);
        }
    }

    private void Update()
    {
        if (GameMenubar == null)
        {
            GameMenubar = GameObject.FindGameObjectWithTag("GameMenu");
            
        }
        if (GameMenubar != null && TextBox == null)
        {
            TextBox = GameMenubar.GetComponent<TMP_InputField>();
        }

        if (CardCoolDownActivated == false)
        {
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
                CardText.text = WordSide1;
                GameManagerScript.CoolDown = 1;
                CardCoolDownActivated = true;
            }
            if (VictoryCheck == true && GameManagerScript.SelectedCard != Position)
            {
                VictoryCheck = false;
                transform.position = new Vector3(-9f, 7f, 0);
                GameManagerScript.NumberOfCardsActive -= 1;
            }
            if (VictoryCheck == true)
            {
                CardText.text = WordSide1;
                if (GameManagerScript.NumberOfCardsActive < 2)
                {
                    GameManagerScript.HiddenButtonActivate();
                    transform.position = new Vector3(-9f, 7f, 0);
                    GameManagerScript.NumberOfCardsActive -= 1;
                }
            }
            if (GameManagerScript.SelectedCard != Position && GameManagerScript.CorrectCheck == 0)
            {
                CardText.text = WordSide2;
            }
        }
        
        if (GameManagerScript.CoolDown == 0)
        {
            CardCoolDownActivated = false;
        }
        if (CardCoolDownActivated == true && GameManagerScript.SelectedCard != Position)
        {
            this.gameObject.GetComponent<Image>().sprite = Cardlocked;
            CardText.text = "";
        }
    }
    public void Selected()
    {
        if (CardCoolDownActivated == false)
        {
            GameManagerScript.SelectedCard = Position;
            GameManagerScript.Word1 = WordSide1;
            GameManagerScript.Word2 = WordSide2;
            GameManagerScript.FirstSelect = false;
            StartCoroutine(SelectTextField());
        }
    }
    private IEnumerator SelectTextField()
    {
        yield return new WaitForSeconds(0.1f);
        TextBox.Select();
    }
}
