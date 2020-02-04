using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master_Script : MonoBehaviour
{

    public string Testing = "Task successful";

    public string[,] ChosenDeckMaster1 =   new string[10,2];

    public bool DeckTransfered = false;

    void Start()
    {
    DontDestroyOnLoad(transform.gameObject);
    Testing = "Task successful";
    }    


    public void Update()
    {
        if (DeckTransfered == true)
        {
        Debug.Log("current deck 0,0 : " + ChosenDeckMaster1[0,0]);
        Debug.Log("current deck 0,0 : " + ChosenDeckMaster1[0,1]);
        SceneManager.LoadScene (sceneName:"Game");
        DeckTransfered = false;
        } 
    }


    public void TestingTransference()
    {
        DeckTransfered = true;
    }
}
