using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Script_2 : MonoBehaviour
{
    public string[,] Deck =  new string[10,2] {{"Cero", "Noll"}, {"Uno", "Ett"}, {"Dos", "två"}, {"Tres", "Tre"}, {"Cuatro", "Fyra"}, {"Cinco", "Fem"}, {"Seis", "Sex"}, {"Siete", "Sju"}, {"Ocho", "Åtta"},{"Numeros 1", "Numbers 1"}};
    private string TestingText = "Task Failed";
    public GameObject MasterObject;
    public Master_Script MasterScript;
    public string[,] ChosenDeckMaster2 =   new string[10,2];
    public int CardLimitInScreen = 9;
    public int CardInScreen = 0;
    private GameObject card;
    public GameObject CardPrefab;
    public GameObject Panel;

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

    public void Update()
    {
        MasterObject = GameObject.Find("Master");
        MasterScript = MasterObject.GetComponent<Master_Script>();
        TestingText = MasterScript.Testing;
    }

    public void TestingClick()
    {
        //Debug.Log(TestingText);
        Debug.Log("current deck 0,0 : " + MasterScript.ChosenDeckMaster1[0, 0]);
        /*var y = 0;
        var z = 0;        
        while ( y != 9)
        {
            while (z != 2)
            {
                ChosenDeckMaster2[y,z] = MasterScript.ChosenDeckMaster1[y,z];
                z += 1;   
            }
            z = 0;
            y += 1;
        }
        */ //Debug.Log("cero: " + ChosenDeckMaster2[0,0]); //Debug.Log("Noll: " + ChosenDeckMaster2[0,1]);
    }

    public void CreateDeck() //This will read the deck array and will call the CreateCard function until all 9 necesary cards are created or if the array ends.
    {
        var NumberOfTotalCards = Deck.Length;
        var WordSide1 = "";
        var WordSide2 = "";

        if (NumberOfTotalCards < CardLimitInScreen) // This adjust the number of cards that needs to be created to the maximum cards in a deck
        {
            CardLimitInScreen = NumberOfTotalCards; // CardLimitInScreen must be turned back to 9 at some point in the code, like when exiting to menu or something, dont forget.
        }


        while (CardInScreen != CardLimitInScreen)
        {
            var TheCardWasCreated = false;

            if (CardInScreen > CardLimitInScreen)
            {
                CardInScreen = CardLimitInScreen;
            }

            WordSide1 = Deck[CardInScreen, 0];
            WordSide2 = Deck[CardInScreen, 1];

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
