using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneScript : MonoBehaviour
{
    // The name of the scene you want to load
    public Loader.Scene sceneName;

    // The button that will be clicked to change the scene
    Button changeSceneButton;

    private void Awake()
    {
        changeSceneButton = GetComponent<Button>();
    }

    private void Start()
    {
        changeSceneButton.onClick.AddListener(ChangeScene);
    }
    
    void ChangeScene()
    {
        // Load the scene with the specified name
        Loader.Load(sceneName);
    }
}
