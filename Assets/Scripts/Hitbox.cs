﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {
    public bool hitActive;
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
            if (collision.tag == "enemy" || collision.tag == "boss") {
                //Destroy(collision.gameObject)  Destroys objects it touches
                GameObject enemy = collision.gameObject;
                Enemy_Health healthScript = enemy.GetComponent<Enemy_Health>();
                if (healthScript.reduceHealth(Player_Move_Prot.playerDamage))
                {
                    if (enemy.GetComponent<Enemy_Move>())
                    {
                        enemy.GetComponent<Enemy_Move>().knockbackEnemy();
                    }
                    if (enemy.GetComponent<EnemyAI>())
                    {
                        enemy.GetComponent<EnemyAI>().knockbackEnemy();
                    }
                    if (enemy.GetComponent<Boss_Move>())
                    {
                        enemy.GetComponent<Boss_Move>().knockbackEnemy();
                    }
                }
                Debug.Log("Enemy hit");
            }
        }
    }
}
