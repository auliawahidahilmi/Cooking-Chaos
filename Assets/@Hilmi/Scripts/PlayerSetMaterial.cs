using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetMaterial : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] meshRenderersChar;

    [SerializeField] private Material[] materialsChar;
    
    void Start()
    {
        int indexMaterial = ES3.Load(ENUM_SAVE_STATE.CHAR_SELECTION.ToString(), 0);
        
        foreach (var mesh in meshRenderersChar)
        {
            mesh.material = materialsChar[indexMaterial];
        }
    }


}
