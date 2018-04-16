using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {


    public static float health;
    public float maxhealth;

    public Image healthb;
    RectTransform healthbar;
    float origSize;
    float delay;
    bool dead;


	// Use this for initialization
	void Start () {
        //hasDied = false;

        health = maxhealth;
        healthbar = healthb.GetComponent<RectTransform>();
        origSize = healthbar.sizeDelta.x;
        delay = 10;
        dead = false;

        if(health <= 0) {
            health = maxhealth;
        }

    }


	// Update is called once per frame
	void FixedUpdate () {
        if(dead == true) { delay -= Time.deltaTime; }
        if ((gameObject.transform.position.y < -20 || health <= 0) && dead != true)
        {
            //Debug.Log("Player Has Died");
            //hasDied = true;
            dead = true;
            Die();
        }

        /*
        if(hasDied == true)
        {
            StartCoroutine("Die");
        }
        */
        
        //Debug.Log("Orig Size: " + origSize + " percent: " + health / maxhealth);
    }
    public static void reduceHealth(int damage) {
        health = health-damage;
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
        transform.GetComponent<Player_Move_Prot>().Die();

        if (delay <= 0) { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
        // yield return null;
        /*
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has died");
        */
    }
}
