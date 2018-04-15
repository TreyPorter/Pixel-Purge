using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Use_After : MonoBehaviour
{

    public GameObject enterDoorText;

    [SerializeField] private string changeLevel;

    public static bool isReady;

   // public GameObject check;

    //initialize
    void Start()
    {
        isReady = false;
       
        enterDoorText.SetActive(false);


    }

    //once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && isReady == true)
        {
            enterDoorText.SetActive(true);
            if (enterDoorText.activeInHierarchy == true && Input.GetButton("Use"))
            {
                SceneManager.LoadScene(changeLevel);
            }

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterDoorText.SetActive(false);
    }

    void Update()
    {
        
    }

}
