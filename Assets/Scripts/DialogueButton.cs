using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DialogueButton : MonoBehaviour
{

    public GameObject enterDoorText;



    //initialize
    void Start()
    {
        enterDoorText.SetActive(false);
    }

    //once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterDoorText.SetActive(true);
            

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterDoorText.SetActive(false);
    }

}