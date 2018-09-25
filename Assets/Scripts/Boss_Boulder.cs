using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Boulder : MonoBehaviour {
	public int objectDamage = 5;
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Object fell on Player");
            Player_Health.reduceHealth(objectDamage);
            StartCoroutine(Restart());
        }
		else if (collision.collider.CompareTag("Floor"))
		{
			StartCoroutine(Restart());
		}
    }
	IEnumerator Restart() {
		yield return new WaitForSeconds(3);
		transform.position = new Vector3(transform.position.x, transform.position.y + 50, 0);
		GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		GetComponent<Rigidbody2D>().isKinematic = true;
	}
}
