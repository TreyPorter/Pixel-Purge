using System.Collections;
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
            if (collision.tag == "enemy")
            {
                Destroy(collision.gameObject); // Destroys objects it touches
            }
        }
    }
}
