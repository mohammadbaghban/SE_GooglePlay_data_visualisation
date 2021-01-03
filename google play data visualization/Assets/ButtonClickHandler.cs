using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickHandler : MonoBehaviour
{
    public void Top1000Clicked()
    {
        SceneManager.LoadScene(2);
    }
    
    public void Top5Clicked()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetKey ("escape")) {
            Application.Quit();
        }
    }
}
