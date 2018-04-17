using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_fall : MonoBehaviour
{

    public int objectDamage = 10;

    private GameObject Player;
    private Rigidbody2D falls;
    private Vector3 originalPos;
    private Quaternion originalRot;

    // Use this for initialization
    void Start()
    {
        originalPos = gameObject.transform.position;
        originalRot = gameObject.transform.rotation;
        falls = GetComponent<Rigidbody2D>();
    }

    void Restart()
    {
        transform.position = originalPos;
        transform.rotation = originalRot;
        falls.velocity = Vector3.zero;
        falls.Sleep();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("Object fell on Player");
            Player_Health.reduceHealth(objectDamage);
            Restart();
        }
		else if (collision.collider.CompareTag("Floor"))
		{
			//Debug.Log("Object fell on floor");
			Restart();
		}
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Floor"){
			//Debug.Log("Object fell on floor");
			Restart();
		}
	}
	
    // Update is called once per frame
    void Update()
    {

    }
}
