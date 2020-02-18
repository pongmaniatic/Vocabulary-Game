using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StartGame : MonoBehaviour
{
    public Button TheButton;
    public Master_Script MasterScript;
    public GameObject MasterObject;
    private bool DoneOnce = false;


    void Awake() // Finds the master object and its script
    {
        //MasterScript = Master_Script.MasterObject;
        MasterObject = GameObject.FindGameObjectWithTag("Master");
        MasterScript = MasterObject.GetComponent<Master_Script>();
    }

    public void Update() //Detects when this object has been clicked
    {
        Button btn = TheButton.GetComponent<Button>();// This detects that this object has been clicked
        btn.onClick.AddListener(TaskOnClick);// THis Runs the TaskOnCLick function when a click is detected
    }
    public void TaskOnClick()
    {
        if (DoneOnce == false)
        {
            MasterScript.CreateDeck();
            DoneOnce = true;
        }
    }
}
