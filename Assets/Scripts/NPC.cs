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

    public string message;  // This is what the NPC tells the player

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        /*
        npcTextUI.gameObject.GetComponent<Text>().text = ("NPC: " + npcText);
        */
    }
}
