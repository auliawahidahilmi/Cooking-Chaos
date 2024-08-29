using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void CloseApp()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
