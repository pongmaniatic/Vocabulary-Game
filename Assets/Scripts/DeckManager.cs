using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    //Deck de numeros
    public string[,] Deck_numbers =  new string[10,2] {{"Cero", "Noll"}, {"Uno", "Ett"}, {"Dos", "två"}, {"Tres", "Tre"}, {"Cuatro", "Fyra"}, {"Cinco", "Fem"}, {"Seis", "Sex"}, {"Siete", "Sju"}, {"Ocho", "Åtta"},{"Numeros 1", "Numbers 1"}};
    public string[,] Deck_colors =  new string[10,2] {{"Rojo", "Röd"}, {"Azul", "Blå"}, {"Amarillo", "Gul"}, {"Blanco", "Vit"}, {"Negro", "Svart"}, {"Verde", "Grön"}, {"Púrpura", "Lila"}, {"Naranja", "Orange"}, {"Celeste ", "Ljusblå"}, {"Colores 1", "Colors 1"}};
    public int NumeroDeDecks = 1;
    public int Awake = 0;  
    public string[,,] All_Decks =   new string[2,10,2];


    private int y = 0;
    private int z = 0;

    void Start()
    {
        LoadDeckToAllDecks(Deck_numbers,All_Decks, 0);
        LoadDeckToAllDecks(Deck_colors,All_Decks, 1);
        Awake = 1;
    }


    public void LoadDeckToAllDecks(string[,] Deck, string[,,] AllDecks, int x)
    {
        
        y = 0;
        z = 0;        
        while ( y != 10)
        {
            while (z != 2)
            {
                AllDecks[x,y,z] = Deck[y,z];
                z += 1;
            }
            z = 0;
            y += 1;
            
        }   
    }




}



//{"Cero", "Noll" }, { "Uno", "Ett" }, { "Dos", "två" }, { "Tres", "Tre" }, { "Cuatro", "Fyra" }, { "Cinco", "Fem" }, { "Seis", "Sex" }, { "Siete", "Sju" }, { "Ocho", "Åtta" }