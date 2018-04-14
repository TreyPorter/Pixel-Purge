using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedController : MonoBehaviour {

	public float speed;
	public Player_Move_Prot user;


	// Use this for initialization
	void Start () {
		user = FindObjectOfType<Player_Move_Prot> ();

		if (user.transform.localScale.x < 0)
			speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}

    

    void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "enemy") {
			GameObject enemy = other.gameObject;
			Enemy_Health healthScript = enemy.GetComponent<Enemy_Health>();
			healthScript.reduceHealth(1);
			//enemy.GetComponent<Enemy_Move>().knockbackEnemy();
			Debug.Log("Enemy hit");
			Destroy (gameObject);
		}
		else
			Destroy (gameObject);
	}

}
