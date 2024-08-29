using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour {


    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform iconContainer;
    [SerializeField] private IconContainerScript iconContent;
    [SerializeField] private Color[] colorList;

    public void SetRecipeSO(RecipeSO recipeSO) {
        recipeNameText.text = recipeSO.recipeName;

        int index = 0;
        
        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList) {
            var iconScript = Instantiate(iconContent, iconContainer);
            iconScript.gameObject.SetActive(true);
            
            iconScript.Setup(index % 2 == 0 ? colorList[0] : colorList[1], kitchenObjectSO.sprite);

            index++;
        }
    }

}