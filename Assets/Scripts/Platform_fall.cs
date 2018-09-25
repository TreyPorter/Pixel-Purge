using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_fall : MonoBehaviour {

    private Rigidbody2D falls;
    public float fallDelay;


	// Use this for initialization
	void Start () {
        falls = GetComponent<Rigidbody2D>();

	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        falls.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
