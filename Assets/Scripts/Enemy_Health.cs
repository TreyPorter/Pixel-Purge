﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {
	//Delete this later: WE'RE GOOD TO GO
    // Update is called once per frame
    public int EnemyHealth;
    void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            //Debug.Log("Enemy Has Died");
            Destroy(gameObject);
        }
    }
}
