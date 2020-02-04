using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Update_volume : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider slider_1;
    public Slider slider_2;

    void Update()
    {
        float volumenActual;
        audioMixer.GetFloat("volume", out volumenActual);

        if (slider_1.GetComponent<Slider>().value != volumenActual)
        {
            slider_1.GetComponent<Slider>().value  = volumenActual;  
        }
        
        if (slider_2.GetComponent<Slider>().value != volumenActual)
        {
            slider_2.GetComponent<Slider>().value  = volumenActual;  
        }

    }
}
