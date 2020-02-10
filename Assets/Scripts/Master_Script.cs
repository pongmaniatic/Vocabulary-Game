using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Script : MonoBehaviour
{
    private static Master_Script MasterObject;

    public string Testing;
    public string[,] ChosenDeckMaster1 = new string[10,2];

    public bool DeckTransfered = false;

    void Awake()
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
