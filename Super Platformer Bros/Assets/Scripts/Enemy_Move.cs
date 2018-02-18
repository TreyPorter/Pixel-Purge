using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Move : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;


    /*
	// Use this for initialization
	void Start () {
		
	}
    */
	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if(hit.distance < 0.7f)
        {
            Flip();
            if(hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject); // Destroys objects it touches
                SceneManager.LoadScene("Prototype1");
            }
            //Destroy(hit.collider.gameObject); // Destroys objects it touches
        }
        /*
        //TODO you should clean this nasty code up
        if(gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        */

	}

    void Flip ()
    {
        if( XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
