using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI[] textScoreLevels;

   [SerializeField] private Button[] buttonsLevel;

   private void Start()
   {
      for (int i = 0; i < textScoreLevels.Length; i++)
      {
	      var value = ES3.Load(ENUM_SAVE_STATE.LEVEL.ToString() + i, 0);
         textScoreLevels[i].text = value.ToString("N0");
      }

      InitSave();

      LoadData();
   }

   void InitSave()
   {
      for (int i = 0; i < 3; i++)
      {
         if (!ES3.KeyExists(ENUM_SAVE_STATE.UNLOCK_LEVEL.ToString() + i))
         {
            ES3.Save(ENUM_SAVE_STATE.UNLOCK_LEVEL.ToString() + i, i == 0);
         }
         
         if (!ES3.KeyExists(ENUM_SAVE_STATE.UNLOCK_ACHIEVEMENT.ToString() + i))
         {
            ES3.Save(ENUM_SAVE_STATE.UNLOCK_ACHIEVEMENT.ToString() + i, false);
         }
      }
   }

   void LoadData()
   {
      for (int i = 0; i < 3; i++)
      {
         buttonsLevel[i].interactable = ES3.Load(ENUM_SAVE_STATE.UNLOCK_LEVEL.ToString() + i, false);
      }
   }
}
