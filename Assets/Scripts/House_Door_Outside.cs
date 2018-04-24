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

    void Update()
    {
        if (Input.GetKeyDown("i")) { SceneManager.LoadScene(changeLevel); }
    }

    //once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name =="Player")
        {
            enterDoorText.SetActive(true);
            if(enterDoorText.activeInHierarchy == true && Input.GetKey("e"))
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
