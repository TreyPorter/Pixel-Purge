using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PickUp : MonoBehaviour
{
    // private Image image;
    
    public GameObject enterDoorText;
    //public bool locked;
   // [SerializeField] private string changeLevel;

    //initialize
    void Start()
    {
        // locked = false;
        enterDoorText.SetActive(false);
       
        

    }


    void OnTriggerStay2D(Collider2D other)
    {

        if ((other.gameObject.tag == "Player")// && (locked == true)
            )
        {
            enterDoorText.SetActive(true);
            if (enterDoorText.activeInHierarchy == true && Input.GetButton("Use"))
            {
                Use_After.isReady = true;
                Destroy(gameObject);

                //SceneManager.LoadScene(changeLevel);
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterDoorText.SetActive(false);
    }

}
