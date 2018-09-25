using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {


    public static float health;
    public float maxhealth;
    public float delay;
    bool dead;

	// Use this for initialization
	void Start () {
        //hasDied = false;
        if(health <= 0) {
            health = maxhealth;
        }
        delay = 3.5f;
        dead = false;
    }


	// Update is called once per frame
	void Update () {
        if (dead == true) { delay -= Time.deltaTime; }
        if (health <= 0)
        {
            //Debug.Log("Player Has Died");
            //hasDied = true;
            health = 0;
            //dead = true;
            Die();
        }
        if(gameObject.transform.position.y < -20 && dead != true) {
            //health = 0;
            delay = 2.75f;
            FindObjectOfType<Health_Bar>().delay = 0.5f;
            health = 0;
            //dead = true;
            Die();
            //dead = 2;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        FindObjectOfType<Player_Health>().transform.Find("Hurt").GetComponent<AudioSource>().Play();
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
        if (FindObjectOfType<BackgroundAudioController>()) { FindObjectOfType<BackgroundAudioController>().currentAudio.Pause(); }
        if (dead != true) { transform.Find("Death").GetComponent<AudioSource>().Play(); }
        dead = true;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        transform.GetComponent<Player_Move_Prot>().Die();
        if (delay <= 0) {
            if(FindObjectOfType<BackgroundAudioController>()) {
                FindObjectOfType<BackgroundAudioController>().currentAudio.Play();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // yield return null;
        /*
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("Player has died");
        */
    }
}
