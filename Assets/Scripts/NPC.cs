using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    /*
    public GameObject npcTextUI;
    public string npcText = "Hello!";
    */

    public bool talks;      // Can talk to player
    public bool canTalk = false;
    public string message;  // This is what the NPC tells the player
    public GameObject npcTextUI;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        /*
        npcTextUI.gameObject.GetComponent<Text>().text = ("NPC: " + npcText);
        */
        Talk();
    }

    public void Talk()
    {
        if (canTalk && Input.GetKey(KeyCode.X)){
            Debug.Log("NPC says: " + message);
            npcTextUI.gameObject.GetComponent<Text>().text = ("NPC: " + message);
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        /*
        if (trig.gameObject.tag == "npc")
        {
            Debug.Log("Talk to NPC?");
            // Why doesn't this work?   - Andy
            if (Input.GetKey(KeyCode.X))
            {
                Debug.Log("NPC says hello!");
            }
        }   */
        /* This code is unnecessary with OnTriggerExit2D()
        if (trig.gameObject.tag == null)
        {
            canTalk = false;
        }*/
        if (trig.gameObject.tag == "Player")
        {
            //sample = trig.GetComponent<NPC>();
            Debug.Log("Talk to NPC?");
            canTalk = true;
        }
    }

    private void OnTriggerExit2D()
    {
        canTalk = false;
        npcTextUI.gameObject.GetComponent<Text>().text = ("");
    }
}
