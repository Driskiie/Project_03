using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public UnityEvent onInteraction;
    public string message;
    
    public void Interact()
    {

        onInteraction.Invoke();


    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("TriggerInteractabe"))
        {
            onInteraction.Invoke();

        }

    }


}
