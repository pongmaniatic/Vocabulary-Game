using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Script : MonoBehaviour
{
    // Singleton
    public static Master_Script MasterObject;// This is used to make this object not be destroyed when changing scenes
    //private static Master_Script MasterObject;// This is used to make this object not be destroyed when changing scenes

    //variables
    public int NumberOfDecks = 1;// This is the number of Decks that will be displayed in the game
    public bool DeckTransfered = false;
    public int CardLimitInScreen = 9;
    public int CardInScreen = 0;
    public int SelectedCard = 0;
    public bool Pos1 = false;
    public bool Pos2 = false;
    public bool Pos3 = false;
    public bool Pos4 = false;
    public bool Pos5 = false;
    public bool Pos6 = false;
    public bool Pos7 = false;
    public bool Pos8 = false;
    public bool Pos9 = false;
    public bool FinishedCreating = false;
    public bool FinishedLoadingCurrent = false;


    private GameObject card;
    public GameObject CardPrefab;
    public GameObject Panel;

    // 9 Numbers cards
    public Card Zero = new Card("Noll", "Cero");
    public Card One = new Card("Ett", "Uno");
    public Card Two = new Card("Två", "Dos");
    public Card Three = new Card("Tre", "Tres");
    public Card Four = new Card("Fyra", "Cuatro");
    public Card Five = new Card("Fem", "Cinco");
    public Card Six = new Card("Sex", "Seis");
    public Card Seven = new Card("Sju", "Siete");
    public Card Eight = new Card("Åtta", "Ocho");

    // 9 Colors cards
    public Card White = new Card("Vit", "Blanco");
    public Card Yellow = new Card("Gul", "Amarillo");
    public Card Brown = new Card("Brun", "Cafe");
    public Card Orange = new Card("Orange", "Naranja");
    public Card Red = new Card("Röd", "Rojo");
    public Card Blue = new Card("Blå", "Azul");
    public Card Green = new Card("Grön", "Verde");
    public Card Black = new Card("Svart", "Negro");
    public Card Purple = new Card("Lila", "Morado");

    //Card arrays
    public Card[] Numbers;
    public Card[] Colors;
    //Decks
    public Deck NumbersDecks;
    public Deck ColorsDecks;
    //Deck array
    public Deck[] AllDecks;
    private int ChosenDeck;//This will be the id for the deck chosen

    private Deck CurrentDeck;
    private Card CurrentCard;


    public void Awake() //This makes The master object survive the change in scene and creates the Deck Numbers
    {
        if (MasterObject != null && MasterObject != this)
        {
            Destroy(gameObject);
        }
        else
        {
            MasterObject = this;
            DontDestroyOnLoad(gameObject);
        }


        //private List<Card> _cartas = new List<Card>();
        //private Dictionary<int, Card> _dictionario = new Dictionary<int, Card>();


        // complete the card arrays
        Numbers = new Card[] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight };
        Colors = new Card[] { White, Yellow, Brown, Orange, Red, Blue, Green, Black, Purple };
        //put them into their respective decks
        NumbersDecks = new Deck(Numbers, 0);
        ColorsDecks = new Deck(Colors,1);
        // Complete an array of decks
        AllDecks = new Deck[] { NumbersDecks, ColorsDecks };
        Debug.Log(AllDecks[0].Cards[0].Side1);
    }

    public void Update() // This detects the signal of the deck having been chosen and loads the next scene
    {
        if (DeckTransfered == true)
        {
        SceneManager.LoadScene (sceneName:"Game");
        DeckTransfered = false;
        } 
    }

    public void DeckLoaded(int Deck)
    {
        DeckTransfered = true;
        ChosenDeck = Deck;
    }

    public void CreateDeck() //This will read the deck array and will call the CreateCard function until all 9 necesary cards are created or if the array ends.
    {
        var WordSide1 = "";
        var WordSide2 = "";

   
        CurrentDeck = AllDecks[ChosenDeck];

        while (CardInScreen != CardLimitInScreen)
        {
            CurrentCard = CurrentDeck.Cards[CardInScreen];
            var TheCardWasCreated = false;

            if (CardInScreen > CardLimitInScreen)
            {
                CardInScreen = CardLimitInScreen;
            }

            WordSide1 = CurrentCard.Side1;
            WordSide2 = CurrentCard.Side2;

            Debug.Log(WordSide1);
            Debug.Log(WordSide2);



            TheCardWasCreated = CreateCard(WordSide1, WordSide2);

            if (TheCardWasCreated == true)
            {
                CardInScreen += 1;

            }

        }
        FinishedCreating = true;
    }

    public bool CreateCard(string Side1, string Side2) //This will randomize 9 numbers, check if it already created a card in that position, if not it creates a card asigned to that position in the screen and so on
    {
        /*int maxAmountOfCards = 10;
        for(int i = 1; i < maxAmountOfCards; i++)
        {

            Pos1 = true;
            //Debug.Log("A Card in the first position was created ");
            card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
            card.transform.parent = Panel.transform;
            card.gameObject.tag = "card";
            var CardScript = card.GetComponent<CardScript>();
            CardScript.Position = i;
            CardScript.WordSide1 = Side1;
            CardScript.WordSide2 = Side2;
            FinishedLoadingCurrent = true;
            return true;
        }*/

        //while (FinishedLoadingCurrent == false)
        //{
        var RandomNumber = Random.Range(1, 10);
        //Debug.Log(RandomNumber);
        if (RandomNumber == 1)
        {
            if (Pos1 == false)
            {
                Pos1 = true;
                //Debug.Log("A Card in the first position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 1;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 2)
        {
            if (Pos2 == false)
            {
                Pos2 = true;
                //Debug.Log("A Card in the second position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 2;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 3)
        {
            if (Pos3 == false)
            {
                Pos3 = true;
                //Debug.Log("A Card in the third position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 3;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 4)
        {
            if (Pos4 == false)
            {
                Pos4 = true;
                //Debug.Log("A Card in the forth position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 4;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 5)
        {
            if (Pos5 == false)
            {
                Pos5 = true;
                //Debug.Log("A Card in the fifth position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 5;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 6)
        {
            if (Pos6 == false)
            {
                Pos6 = true;
                //Debug.Log("A Card in the sixth position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 6;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 7)
        {
            if (Pos7 == false)
            {
                Pos7 = true;
                //Debug.Log("A Card in the seventh position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 7;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 8)
        {
            if (Pos8 == false)
            {
                Pos8 = true;
                //Debug.Log("A Card in the eighth position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 8;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
            RandomNumber = Random.Range(0, 9);
        }
        if (RandomNumber == 9)
        {
            if (Pos9 == false)
            {
                Pos9 = true;
                //Debug.Log("A Card in the ninth position was created ");
                card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
                card.transform.parent = Panel.transform;
                card.gameObject.tag = "card";
                var CardScript = card.GetComponent<CardScript>();
                CardScript.Position = 9;
                CardScript.WordSide1 = Side1;
                CardScript.WordSide2 = Side2;
                FinishedLoadingCurrent = true;
                return true;
            }
        }
        return false;
    }
}

public struct Deck
{
    public Card[] Cards;
    public int ID;

    public Deck(Card[] cards,int id)
    {
        Cards = cards;
        ID = id;
    }
}

public struct Card
{
    public int cardSide;
    public string Side1;
    public string Side2;

    public Card(string S1, string S2, int side = 0)
    {
        Side1 = S1;
        Side2 = S2;
        cardSide = side;
    }
}