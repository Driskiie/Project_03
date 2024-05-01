using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] string[] lines;
    [SerializeField] float textSpeed;
    [SerializeField] GameObject dialoguePopUp;
    [SerializeField] Collider TriggerElement;
    [SerializeField] AudioSource typing;
    

    private int index;

    // Start is called before the first frame update
    void Start()
    {

        textComponent.text = string.Empty;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

    }







    public void StartDialogue()
    {

        if (dialoguePopUp != isActiveAndEnabled)
        {
            gameObject.SetActive(true);
            index = 0;


            


            StartCoroutine(TypeWords());

            Time.timeScale = 0.0001f;
            


        }
    }

    IEnumerator TypeWords()
    {
        typing.Play();

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            typing.Stop();

            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeWords());
        }

        else
        {
            if (TriggerElement != null)
            {

                TriggerElement.gameObject.SetActive(false);
            }
            typing.Stop();
            textComponent.text = string.Empty;
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            

        }
    }


}
