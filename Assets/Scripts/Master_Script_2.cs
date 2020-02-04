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

    public void Update()
    {
        MasterObject = GameObject.Find("Master");
        MasterScript = MasterObject.GetComponent<Master_Script>();
        TestingText = MasterScript.Testing;
    }

    public void TestingClick()
    {
        Debug.Log(TestingText);
        Debug.Log("Deck at play 0,0 : " + MasterScript.ChosenDeckMaster1[0,0]);
        Debug.Log("Deck at play 0,0 : " + MasterScript.ChosenDeckMaster1[0,1]);
        /*
        var y = 0;
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
        */


        //Debug.Log("cero: " + ChosenDeckMaster2[0,0]);
        //Debug.Log("Noll: " + ChosenDeckMaster2[0,1]);
        
    }
}
