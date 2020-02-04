using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    private int pagina = 1;
    private int MaxPagina = 1;
    private int CurrentLoadedDecks = 0;
    private int DecksInPage = 0;
    private GameObject Deck;

    public TextMeshProUGUI TextPagina;
    public DeckManager deckManager;
    public GameObject Prefab_Deck_Vacio;
    public GameObject Ordenador_de_Decks;

    void Update()
    {

        if (CurrentLoadedDecks == 0)
            {
                if (pagina == 1)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 0;    
                }
                if (pagina == 2)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 6;    
                }
                if (pagina == 3)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 12;    
                }
                if (pagina == 4)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 18;    
                }
                if (pagina == 5)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 24;    
                }
                if (pagina == 6)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 30;    
                }
                if (pagina == 7)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 36;    
                }
                if (pagina == 8)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 42;   
                }
                if (pagina == 9)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 48;    
                }
                if (pagina == 10)
                {
                    DecksInPage = deckManager.NumeroDeDecks - 54;    
                }

                while (CurrentLoadedDecks != DecksInPage)
                {
                     
                    if (CurrentLoadedDecks == 0)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(-3,1,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform;
                        Deck.gameObject.tag="Deck";
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 1;


                    }
                    if (CurrentLoadedDecks == 1)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(0,1,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform;    
                        Deck.gameObject.tag="Deck"; 
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 2;   
                    }
                    if (CurrentLoadedDecks == 2)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(3,1,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform;  
                        Deck.gameObject.tag="Deck";
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 3;      
                    }
                    if (CurrentLoadedDecks == 3)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(-3,-2,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform; 
                        Deck.gameObject.tag="Deck";
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 4;      
                    }
                    if (CurrentLoadedDecks == 4)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(0,-2,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform; 
                        Deck.gameObject.tag="Deck"; 
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 5;      
                    }
                    if (CurrentLoadedDecks == 5)
                    {   
                        Deck = Instantiate(Prefab_Deck_Vacio, new Vector3(3,-2,100), Quaternion.identity);
                        Deck.transform.parent = Ordenador_de_Decks.transform; 
                        Deck.gameObject.tag="Deck"; 
                        var DeckScript = Deck.GetComponent<Deck_script>();
                        DeckScript.count = 6;      
                    }
                    CurrentLoadedDecks += 1;
                }
            }        
    }

    public void NextPage()
    {
        //This seeks and destroys all objects with the tag "deck" to recreate the decks onscreen with new decks
        GameObject[] Dekcs_On_Screen = GameObject.FindGameObjectsWithTag("Deck");
        for(int i=0; i< Dekcs_On_Screen.Length; i++)
        {
            Destroy(Dekcs_On_Screen[i]);
        }


        // This changes de page to a next one if possible and sets up de deck shown onscreen
        if (deckManager.NumeroDeDecks < 7)
        {
        MaxPagina = 1;
        }
        if (deckManager.NumeroDeDecks < 13 && deckManager.NumeroDeDecks >= 7)
        {
        MaxPagina = 2;
        }
        if (deckManager.NumeroDeDecks < 19 && deckManager.NumeroDeDecks >= 13)
        {
        MaxPagina = 3;
        }
        if (deckManager.NumeroDeDecks < 25 && deckManager.NumeroDeDecks >= 19)
        {
        MaxPagina = 4;
        }
        if (deckManager.NumeroDeDecks < 31 && deckManager.NumeroDeDecks >= 25)
        {
        MaxPagina = 5;
        }
        if (deckManager.NumeroDeDecks < 37 && deckManager.NumeroDeDecks >= 31)
        {
        MaxPagina = 6;
        }
        if (deckManager.NumeroDeDecks < 43 && deckManager.NumeroDeDecks >= 37)
        {
        MaxPagina = 7;
        }
        if (deckManager.NumeroDeDecks < 49 && deckManager.NumeroDeDecks >= 43)
        {
        MaxPagina = 8;
        }
        if (deckManager.NumeroDeDecks < 55 && deckManager.NumeroDeDecks >= 49)
        {
        MaxPagina = 9;
        }
        if (deckManager.NumeroDeDecks < 61 && deckManager.NumeroDeDecks >= 55)
        {
        MaxPagina = 10;
        }
        

        if (pagina > 0 && pagina < MaxPagina)
        {
            pagina += 1;
        }
        CurrentLoadedDecks = 0;
        TextPagina.text = pagina.ToString();   
    }

    public void PriorPage()
    {

        //This seeks and destroys all objects with the tag "deck" to recreate the decks onscreen with new decks
        GameObject[] Dekcs_On_Screen = GameObject.FindGameObjectsWithTag("Deck");
        for(int i=0; i< Dekcs_On_Screen.Length; i++)
        {
            Destroy(Dekcs_On_Screen[i]);
        }

        // This changes de page to a prior one if possible and sets up de deck shown onscreen
        if (pagina > 1)
        {
            pagina -= 1;
        }
        CurrentLoadedDecks = 0;
        TextPagina.text = pagina.ToString(); 
        
    }

}



