using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Deck_script : MonoBehaviour
{
    public Button TheButton;
    public TextMeshProUGUI Options_text;
    public Master_Script MasterScript;

    public GameObject MasterObject;

    public int count = 0;


    void Awake() // Finds the master object and its script
    {
        MasterScript = Master_Script.MasterObject;
        //MasterObject = GameObject.Find("Master");
        //MasterScript = MasterObject.GetComponent<Master_Script>();
    }

    public void Update() //Detects when this object has been clicked
    {
        Button btn = TheButton.GetComponent<Button>();// This detects that this object has been clicked
        btn.onClick.AddListener(TaskOnClick);// THis Runs the TaskOnCLick function when a click is detected
    }

    public void TaskOnClick()
    {
        MasterScript.DeckLoaded(count);
    }
}
