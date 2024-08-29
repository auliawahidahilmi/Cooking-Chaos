using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAchievementCheck : MonoBehaviour
{
    [SerializeField] private GameObject targetCheck;

    [SerializeField]
    private string saveId;

    private void Start()
    {
        targetCheck.gameObject.SetActive(ES3.Load(saveId, false));
    }
}
