using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Textbox_editor : MonoBehaviour {

    public bool lvlchange;
    [SerializeField] public string lvl;
    public GameObject txtBox;

    public Text txtUsed;

    public TextAsset txtF;

    public string[] txtL;
    public int curLine;
    public int endLine;

    public bool isActive;

    public Player_Move_Prot player;

    public bool stopPlayerMove;

    
    
	// Use this for initialization
	void Start () {

        player = FindObjectOfType<Player_Move_Prot>();
		if (txtF != null)
        {
            txtL = (txtF.text.Split('\n'));
        }

        if(endLine == 0)
        {
            endLine = txtL.Length - 1;
        }

        if(isActive)
        {
            EnableTxtBox();
            if(stopPlayerMove)
            {
                player.canMove = false;
            }
        }
        else
        {
            DisableTxtBox();
            
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(!isActive)
        {
            return;
        }


        txtUsed.text = txtL[curLine];
        if(Input.GetKeyDown(KeyCode.Return))
        {
            curLine += 1;
        }
        if(curLine >endLine)
        {
            if(lvlchange)
            {
                SceneManager.LoadScene(lvl);
            }
           
            DisableTxtBox();
        }
	}

    public void EnableTxtBox()
    {
        txtBox.SetActive(true);
        isActive = true;
    }

    public void DisableTxtBox()
    {
        txtBox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadS(TextAsset txtUsed)
    {
        if (txtUsed != null)
        {
            txtL = new string[1];
            txtL = (txtUsed.text.Split('\n'));
        }
    }
}
