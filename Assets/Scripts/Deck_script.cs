using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deck_script : MonoBehaviour
{
    public Button TheButton;
    public GameObject OrdenadorDeDecks;
    public TextMeshProUGUI Options_text;
    public int count = 0; 
    public DeckManager deckManager;

    public GameObject MasterObject;
    public Master_Script MasterScript;




    public void Update()
    {
        MasterObject = GameObject.Find("Master");
        MasterScript = MasterObject.GetComponent<Master_Script>();
        

        OrdenadorDeDecks = GameObject.Find("Ordenador_de_Decks");
        deckManager = OrdenadorDeDecks.GetComponent<DeckManager>();
        if (count <= deckManager.NumeroDeDecks )
        {
            Options_text.text = deckManager.All_Decks[count-1,9,1]; 
        }  

        Button btn = TheButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);  

        
        
    }

    public void TaskOnClick()
    {
        // This loads only the Chosen Deck into an array given 
        // to a persistent object so it can be read when played.
        var y = 0;
        var z = 0;        
        while ( y != 9)
        {
            while (z != 2)
            {
                MasterScript.ChosenDeckMaster1[y,z] = deckManager.All_Decks[count-1,y,z];
                
                z += 1;
                
            }
            z = 0;
            y += 1;
        }
        MasterScript.TestingTransference();
        
        
    }
   
}
