using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    
    private void Awake()
    {
        instance = this; 
    
    }
    [SerializeField] TMP_Text  interactiontext;
     public void EnableHUD(string text)
    {
        interactiontext.text = text + " (E)";
        interactiontext.gameObject.SetActive(true);
    }
    public void DisableHUD()
    {
         interactiontext.gameObject.SetActive(false);
    
    }
}
