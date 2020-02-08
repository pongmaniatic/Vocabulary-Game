using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Script : MonoBehaviour
{

    public string Testing;

    public string[,] ChosenDeckMaster1 = new string[10,2];

    public bool DeckTransfered = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Testing = "Task successful";
    }


    public void Update()
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
