using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class Master_Script : MonoBehaviour
{
    //Debug.Log("");
    // Singleton
    public static Master_Script MasterObject;// This is used to make this object not be destroyed when changing scenes

    //variables
    public int NumberOfDecks = 1;// This is the number of Decks that will be displayed in the game
    public bool DeckTransfered = false;
    public int CardLimitInScreen = 9;
    public int CardInScreen = 0;
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
    public Card Zero = new Card("noll", "cero");
    public Card One = new Card("ett", "uno");
    public Card Two = new Card("två", "dos");
    public Card Three = new Card("tre", "tres");
    public Card Four = new Card("fyra", "cuatro");
    public Card Five = new Card("fem", "cinco");
    public Card Six = new Card("sex", "seis");
    public Card Seven = new Card("sju", "siete");
    public Card Eight = new Card("åtta", "ocho");

    // 9 Colors cards
    public Card White = new Card("vit", "blanco");
    public Card Yellow = new Card("gul", "amarillo");
    public Card Brown = new Card("brun", "cafe");
    public Card Orange = new Card("orange", "naranja");
    public Card Red = new Card("röd", "rojo");
    public Card Blue = new Card("blå", "azul");
    public Card Green = new Card("grön", "verde");
    public Card Black = new Card("svart", "negro");
    public Card Purple = new Card("lila", "morado");

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

    public TextMeshProUGUI myText;
    public int testingSaveSystem = 0;
    private const string SAVE_SEPRATOR = "#SAVE-VALUE#";

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
        // complete the card arrays
        Numbers = new Card[] { Zero, One, Two, Three, Four, Five, Six, Seven, Eight };
        Colors = new Card[] { White, Yellow, Brown, Orange, Red, Blue, Green, Black, Purple };


        //put them into their respective decks
        NumbersDecks = new Deck(Numbers, 0, "Numbers");
        ColorsDecks = new Deck(Colors, 1, "Colors");

        // Complete an array of decks
        AllDecks = new Deck[] { NumbersDecks, ColorsDecks };

        SaveObject saveObject = new SaveObject{TextingText = 0};
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log(json);
        SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
        Debug.Log(loadedSaveObject.TextingText);
    } 
    public void Update() // This detects the signal of the deck having been chosen and loads the next scene
    {
        if (DeckTransfered == true)
        {
            SceneManager.LoadScene(sceneName: "Game");
            DeckTransfered = false;
        }
        myText.text = testingSaveSystem.ToString();

    }
    public void DeckLoaded(int Deck)
    {
        DeckTransfered = true;
        ChosenDeck = Deck;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu_principal");
    }
    public void CreateDeck() //This will read the deck array and will call the CreateCard function until all 9 necesary cards are created or if the array ends.
    {
        var WordSide1 = "";
        var WordSide2 = "";
        int maxAmountOfCards = 9;
        int RandomNumber;
        int currentItemFromList;
        var cardPositions = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });
        var sizeOfList = cardPositions.Count;

        for (int i = 0; i < maxAmountOfCards; i++)
        {
            Panel = GameObject.FindGameObjectWithTag("Panel");
            sizeOfList = cardPositions.Count;
            RandomNumber = Random.Range(0, sizeOfList - 1);
            currentItemFromList = cardPositions[RandomNumber];
            WordSide2 = MasterObject.AllDecks[ChosenDeck].Cards[currentItemFromList].Side1;
            WordSide1 = MasterObject.AllDecks[ChosenDeck].Cards[currentItemFromList].Side2;
            // generate the card
            card = Instantiate(CardPrefab, new Vector3(-3, 1, 100), Quaternion.identity);
            card.transform.SetParent(Panel.transform);
            card.gameObject.tag = "card";
            var CardScript = card.GetComponent<CardScript>();
            CardScript.Position = i + 1;
            CardScript.WordSide1 = WordSide1;
            CardScript.WordSide2 = WordSide2;
            FinishedLoadingCurrent = true;
            cardPositions.Remove(cardPositions[RandomNumber]);
            
        }
    }
    /*
    public bool CreateCard(string Side1, string Side2) //This will randomize 9 numbers, check if it already created a card in that position, if not it creates a card asigned to that position in the screen and so on
    {
        var RandomNumber = Random.Range(1, 10);
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
*/


    public void Plus()
    {
        testingSaveSystem += 1;
    }
    public void Minus()
    {
        testingSaveSystem -= 1;
    }
    public void Save()
    {
        int goldAmount = testingSaveSystem;
        SaveObject saveObject = new SaveObject {
            TextingText = goldAmount
        };
        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.txt", json);
    }
    public void Load()
    {
        
    }

    private class SaveObject
    {
        public int TextingText;
    }

}
public struct Deck
{
    public Card[] Cards;
    public int ID;
    public string DeckName;

    public Deck(Card[] cards,int id, string name)
    {
        Cards = cards;
        ID = id;
        DeckName = name;
    }
}
public struct Card //implements Seralizable
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
/*
Seralize()
    Deserlialize()
    Marshall
    Unmarchall
    
     * {
     *  cardSide: 1,
     *  Side1: "Word one",
     *  Side2: "Word two
     * }
     */
}