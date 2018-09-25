using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWith : MonoBehaviour {

    public bool track;
	// Use this for initialization
	void Start () {

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
           track = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //moving = true;
            collision.collider.transform.SetParent(null);
            track = false;
        }
    }
    // Update is called once per frame
    void Update () {

	}
}
