using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class House_Door_Outside : MonoBehaviour {

    public GameObject enterDoorText;

    [SerializeField] private string changeLevel;

    //initialize
    void Start()
    {
        enterDoorText.SetActive(false);
    }

    //once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag =="Player")
        {
            enterDoorText.SetActive(true);
            if(enterDoorText.activeInHierarchy == true && Input.GetButton("Use"))
            {
                SceneManager.LoadScene(changeLevel);
            }
           
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterDoorText.SetActive(false); 
    }

}
