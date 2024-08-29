using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI timerText;


    private void Update() {
        timerText.text = KitchenGameManager.Instance.GetGamePlayingTimerNormalized();
    }
}