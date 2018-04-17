using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour {
    // Update is called once per frame
    public int EnemyHealth;
    void Update()
    {
        if (gameObject.transform.position.y < -20 || EnemyHealth <= 0)
        {
            //Debug.Log("Enemy Has Died");
            StartCoroutine(kill());
        }
    }
    public void reduceHealth(int damage) {
        EnemyHealth = EnemyHealth-damage;
        //Debug.Log("Enemy Health: " + EnemyHealth);
    }
    IEnumerator kill() {
        yield return new WaitForSeconds(.01f);
        Destroy(gameObject);
    }
}
