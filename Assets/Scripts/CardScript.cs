using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public string WordSide1 = "Empty";
    public string WordSide2 = "Empty";
    public int Checks = 0;
    public int Position = 0;
    public bool CurrentSide = true;
    public TextMeshProUGUI Word;

    public GameObject Master2;
    public Master_Script_2 MasterScript2;
    public Sprite CardSelesctedSprite;
    public Sprite CardSprite;

    // Start is called before the first frame update 
    void Start()
    {

        Master2 = GameObject.Find("Master2");
        MasterScript2 = Master2.GetComponent<Master_Script_2>();

        if (Position == 1)
        {
            transform.position = new Vector3(-3.65f, 2.8f, 0);
        }
        if (Position == 2)
        {
            transform.position = new Vector3(0, 2.8f, 0);
        }
        if (Position == 3)
        {
            transform.position = new Vector3(3.65f, 2.8f, 0);
        }
        if (Position == 4)
        {
            transform.position = new Vector3(-3.65f, 0.58f, 0);
        }
        if (Position == 5)
        {
            transform.position = new Vector3(0, 0.58f, 0);
        }
        if (Position == 6)
        {
            transform.position = new Vector3(3.65f, 0.58f, 0);
        }
        if (Position == 7)
        {
            transform.position = new Vector3(-3.65f, -1.64f, 0);
        }
        if (Position == 8)
        {
            transform.position = new Vector3(0, -1.64f, 0);
        }
        if (Position == 9)
        {
            transform.position = new Vector3(3.65f, -1.64f, 0);
        }

        Word.text = WordSide2;

    }

    public void Update()
    {
        if (MasterScript2.SelectedCard == Position)
        {
            this.gameObject.GetComponent<Image>().sprite = CardSelesctedSprite;
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = CardSprite;
        }
    }

    public void Selected()
    {
        MasterScript2.SelectedCard = Position;
        Debug.Log(MasterScript2.SelectedCard);

    }
}
