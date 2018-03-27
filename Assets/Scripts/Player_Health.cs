using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour {


    public int health;
	/*
    public bool hasDied;

	// Use this for initialization
	void Start () {
        hasDied = false;
	}
	*/

	// Update is called once per frame
	void Update () {
		if(gameObject.transform.position.y < -20)
        {
            //Debug.Log("Player Has Died");
            //hasDied = true;
            Die();
        }

        /*
        if(hasDied == true)
        {
            StartCoroutine("Die");
        }
        */
	}


    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        // Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "enemy")
        {
            Die();
        }
    }
    */

    void Die ()
    {
        SceneManager.LoadScene("Prototype2");
        // yield return null;
        /*
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has died");
        */
    }
}
