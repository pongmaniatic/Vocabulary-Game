﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_behavior : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit(); 
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
