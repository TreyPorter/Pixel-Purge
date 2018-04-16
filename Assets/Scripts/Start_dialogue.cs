using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Start_dialogue : MonoBehaviour {

    public TextAsset txtUsed;
    private bool changeSomething;
    //public GameObject sayHi;
    public int startLine;
    public int endLine;
    //public bool Key;
    public Textbox_editor txtBox;
   // public Sequence1to1House KeyLock;
    public bool destroyActive;
    public GameObject desSomething;
    public bool needActivate;
    private bool waitPress;
	// Use this for initialization
	void Start () {
        //Key = false;
        //KeyLock = FindObjectOfType<Sequence1to1House>();
        txtBox = FindObjectOfType<Textbox_editor>();
        //sayHi.SetActive(false);

    }

	// Update is called once per frame
	void Update () {
		if(waitPress && Input.GetKeyDown(KeyCode.E))
        {

            txtBox.ReloadS(txtUsed);
            txtBox.curLine = startLine;
            txtBox.endLine = endLine;
            txtBox.EnableTxtBox();

            if (destroyActive)
            {

                Destroy(gameObject);
            }
            //Key = true;
           // KeyLock.locked = Key;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.name == "Player")
        {

            if(needActivate)
            {
              // sayHi.SetActive(true);
                waitPress = true;
                return;

            }
            txtBox.ReloadS(txtUsed);
            txtBox.curLine = startLine;
            txtBox.endLine = endLine;
            txtBox.EnableTxtBox();

            if(destroyActive)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // sayHi.SetActive(false);
        if (collision.name == "Player")
        {
            waitPress = false;
        }
    }
}
