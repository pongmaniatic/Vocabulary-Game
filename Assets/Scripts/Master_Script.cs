using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Script : MonoBehaviour
{
    private static Master_Script MasterObject;
    public int NumberOfDecks = 1;

    //This is the Numbers deck created manually in code, later i will make it so it can read it from a text
    public Card Zero = new Card("Noll", "Cero");
    public Card One = new Card("Ett", "Uno");
    public Card Two = new Card("Två", "Dos");
    public Card Three = new Card("Tre", "Tres");
    public Card Four = new Card("Fyra", "Cuatro");
    public Card Five = new Card("Fem", "Cinco");
    public Card Six = new Card("Sex", "Seis");
    public Card Seven = new Card("Sju", "Siete");
    public Card Eight = new Card("Åtta", "Ocho");
 

    public string[,] ChosenDeckMaster1 = new string[10,2];
    public bool DeckTransfered = false;

    void Awake() //This has the only purpose of making The master object survive the change in scene
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

        Card[] Numbers = new Card[] {Zero, One, Two, Three, Four, Five, Six, Seven, Eight};
        Deck NumbersDeck = new Deck(Numbers);
    }

    public void Update() // This detects the signal of the deck having been chosen and loads the next scene
    {
        if (DeckTransfered == true)
        {
        Debug.Log("current deck 0,0 : " + ChosenDeckMaster1[0,0]);
        SceneManager.LoadScene (sceneName:"Game");
        DeckTransfered = false;
        } 
    }


    public void TestingTransference()
    {
        DeckTransfered = true;
    }

    public void TestingClick()
    {
        Debug.Log("current deck 0,0 : " + ChosenDeckMaster1[0, 0]);
    }

}

public struct Deck
{
    public Card[] TheDeck;

    public Deck(Card[] Cards)
    {
        TheDeck = Cards;
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