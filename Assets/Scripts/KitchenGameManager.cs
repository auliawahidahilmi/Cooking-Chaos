using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public enum ENUM_SAVE_STATE
{
    LEVEL,
    UNLOCK_ACHIEVEMENT,
    UNLOCK_LEVEL,
    CHAR_SELECTION,
    USE_APRON,
    USE_HAT
}

public class KitchenGameManager : MonoBehaviour {


    public static KitchenGameManager Instance { get; private set; }

    [SerializeField] private Button buttonPause;

    [SerializeField] private TextMeshProUGUI textScore;

    public int CurrentLevel;

    private int _score;
    
    public int Score
    {
        get => _score;
        set
        {
            _score = value;

            textScore.text = value.ToString("N0");
        }
    }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;


    private enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }


    private State state;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer;
    
    [SerializeField]
    private float gamePlayingTimerMax = 30f;
    private bool isGamePaused = false;


    private void Awake() {
        Instance = this;

        state = State.WaitingToStart;
    }

    private void Start() {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
        
        buttonPause.onClick.AddListener(() => TogglePauseGame());
        
        state = State.CountdownToStart;
        OnStateChanged?.Invoke(this, EventArgs.Empty);

        Score = 0;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e) {
        if (state == State.WaitingToStart) {
            state = State.CountdownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e) {
        TogglePauseGame();
    }

    private void Update() {
        switch (state) {
            case State.WaitingToStart:
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f) {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f) {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
    }

    public bool IsGamePlaying() {
        return state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive() {
        return state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer() {
        return countdownToStartTimer;
    }

    public bool IsGameOver() {
        return state == State.GameOver;
    }

    public string GetGamePlayingTimerNormalized()
    {
        string result = "";
        
        int minutes = Mathf.FloorToInt(gamePlayingTimer / 60);
        int seconds = Mathf.FloorToInt(gamePlayingTimer % 60);
        
        result = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        return gamePlayingTimer <= 0 ? "00:00" : result;
    }
    

    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;

            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

}