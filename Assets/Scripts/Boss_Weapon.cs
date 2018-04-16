using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour {
    public bool hitActive;
	public int swordDamage;
	// Use this for initialization
	void Start () {
        hitActive = false;
	}

	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && hitActive == true)
        {
            if (collision.tag == "Player") {
				Player_Health.reduceHealth(swordDamage);
		        Debug.Log("Player Health: " + Player_Health.health);
            }
        }
    }
}
