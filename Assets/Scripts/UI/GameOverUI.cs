using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI recipesDeliveredText;

    [SerializeField] private TextMeshProUGUI textScore;

    [SerializeField] private Image imageResult;

    [SerializeField] private Sprite[] spritesResult;


    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsGameOver()) {
            
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
            textScore.text = KitchenGameManager.Instance.Score.ToString("N0");
            imageResult.sprite = KitchenGameManager.Instance.Score <= DB_GameplayData.GetEntity(0)
                .LevelData[KitchenGameManager.Instance.CurrentLevel].ScoreMinimal
                ? spritesResult[0]
                : spritesResult[1];


            if (KitchenGameManager.Instance.Score >= DB_GameplayData.GetEntity(0)
                    .LevelData[KitchenGameManager.Instance.CurrentLevel].ScoreMaximal)
            {
                ES3.Save(ENUM_SAVE_STATE.UNLOCK_ACHIEVEMENT.ToString() + KitchenGameManager.Instance.CurrentLevel, true);
            }   
                
            if (KitchenGameManager.Instance.CurrentLevel < 2 && KitchenGameManager.Instance.Score >= DB_GameplayData.GetEntity(0)
                    .LevelData[KitchenGameManager.Instance.CurrentLevel].ScoreMinimal)
            {
                
                ES3.Save(ENUM_SAVE_STATE.UNLOCK_LEVEL.ToString() + (KitchenGameManager.Instance.CurrentLevel + 1), true);
            }
            

            if (KitchenGameManager.Instance.Score > ES3.Load(ENUM_SAVE_STATE.LEVEL.ToString() + KitchenGameManager.Instance.CurrentLevel, 0))
            {
                ES3.Save(ENUM_SAVE_STATE.LEVEL.ToString() + KitchenGameManager.Instance.CurrentLevel, KitchenGameManager.Instance.Score);
            }
            
            Show();
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}