using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;


public class CharacterSelectionController : MonoBehaviour
{
    [SerializeField] private Button buttonConfirmChar;

    [SerializeField] private HorizontalScrollSnap hss;

    [SerializeField] private MeshRenderer[] meshRenderersChar;

    [SerializeField] private Material[] materialsChar;

    [Header("Achievement")]
    
    [SerializeField] private Button buttonApron;

    [SerializeField] private GameObject objApron;
    
    [SerializeField] private Button buttonHat;

    [SerializeField] private GameObject objHat;

    private void Start()
    {
        buttonConfirmChar.onClick.AddListener(() =>
        {
            foreach (var mesh in meshRenderersChar)
            {
                mesh.material = materialsChar[hss.CurrentPage];
            }
            
            ES3.Save(ENUM_SAVE_STATE.CHAR_SELECTION.ToString(), hss.CurrentPage);
        });
        
        buttonApron.onClick.AddListener(() =>
        {
            objApron.SetActive(!objApron.activeSelf);
            ES3.Save(ENUM_SAVE_STATE.USE_APRON.ToString(), objApron.activeSelf);
        });
        
        buttonHat.onClick.AddListener(() =>
        {
            objHat.SetActive(!objHat.activeSelf);
            ES3.Save(ENUM_SAVE_STATE.USE_HAT.ToString(), objHat.activeSelf);
        });
    }
}
