using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameLoad : MonoBehaviour
{
    [SerializeField] private Button buttonMiniGame;

    private void Start()
    {
        buttonMiniGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MiniGame");
        });
    }
    
}
