using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float PlayerReach = 3f;
    Interactable currentInteract;
    

    void Update()
    {
        checkInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteract != null)
        {

            currentInteract.Interact();

        }
    }
    void checkInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out hit, PlayerReach))
        {
            if (hit.collider.tag == "Interactable")
            {


                Interactable newInteractable = hit.collider.GetComponent<Interactable>();


                if (newInteractable.enabled)
                {

                    SetCurrentInteractable(newInteractable);


                }
                else
                {
                    DisableCurrentInteraction();

                }
            }
            else
            {
                DisableCurrentInteraction();

            }


        }
        else
        {

            DisableCurrentInteraction();

        }
    }
    void SetCurrentInteractable(Interactable newInteractable)
    {
        currentInteract = newInteractable;
        HUDController.instance.EnableHUD(currentInteract.message);



    }
    void DisableCurrentInteraction()
    {
        HUDController.instance.DisableHUD();
        if (currentInteract)
        {
            currentInteract = null;


        }



    }
}
