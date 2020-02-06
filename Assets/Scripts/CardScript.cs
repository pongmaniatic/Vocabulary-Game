using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public string WordSide1 = "Empty";
    public string WordSide2 = "Empty";
    public int Checks = 0;
    public int Position = 0;
    public bool CurrentSide = true;

    // Start is called before the first frame update 
    void Start()
    {
        if (Position == 1)
        {
            transform.position = new Vector3(-5, 3, 0);
        }
        if (Position == 2)
        {
            transform.position = new Vector3(0, 3, 0);
        }
        if (Position == 3)
        {
            transform.position = new Vector3(5, 3, 0);
        }
        if (Position == 4)
        {
            transform.position = new Vector3(-5, 0, 0);
        }
        if (Position == 5)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        if (Position == 6)
        {
            transform.position = new Vector3(5, 0, 0);
        }
        if (Position == 7)
        {
            transform.position = new Vector3(-5, -3, 0);
        }
        if (Position == 8)
        {
            transform.position = new Vector3(0, -3, 0);
        }
        if (Position == 9)
        {
            transform.position = new Vector3(5, -3, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
