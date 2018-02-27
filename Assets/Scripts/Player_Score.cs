using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;

	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            SceneManager.LoadScene("Prototype2");
        }

       //Debug.Log(timeLeft);
	}


    private void OnTriggerEnter2D(Collider2D trig)
    {
        //Debug.Log("Touched the End of the Level");
        if (trig.gameObject.name == "exit")
        {
            CountScore();
        }
        if (trig.gameObject.tag == "coin")
        {
            playerScore += 100;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore += (int)(timeLeft * 10);
        Debug.Log(playerScore);
    }

}
