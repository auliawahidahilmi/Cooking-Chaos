using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconContainerScript : MonoBehaviour
{
    [SerializeField] private Image bg;

    [SerializeField] private Image icon;

    public void Setup(Color color, Sprite sprite)
    {
        bg.color = color;

        icon.sprite = sprite;
    }
}
