using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingLeft = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    Animator anim;
    // public bool isDead;

    //NPC talking, moved in NPC
    //public GameObject npcTextUI;
    //public NPC sample;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", false);
        anim.SetBool("IsCrouching", false);
        anim.SetBool("IsGrounded", true);
    }

	// Update is called once per frame
	void Update () {
        PlayerMove();
        //PlayerRaycast();
        Animate();
	}

    void PlayerMove()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        // ANIMATIONS
        // PLAYER DIRECTION
        if (moveX < 0.0f && facingLeft == false)
        {
            FlipPlayer();
        }
        else if(moveX > 0.0f && facingLeft == true)
        {
            FlipPlayer ();
        }
        // PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
        anim.SetTrigger("Jump");
        anim.SetBool("IsGrounded", isGrounded);
    }

    void Slide()
    {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerJumpPower);
        anim.SetTrigger("Attack");
    }

    void FlipPlayer()
    {
        facingLeft = !facingLeft;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name);

        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.collider.tag == "box_2")
        {
            //Debug.Log("Hit box");
            Destroy(rayUp.collider.gameObject);
        }

        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && col.collider.tag != "enemy")
        {
            isGrounded = true;
            anim.SetTrigger("Land");
            anim.SetBool("IsGrounded", isGrounded);
        }

        if (rayDown != null && rayDown.collider != null && col.collider.tag == "enemy")
        {
            //Debug.Log("Squished enemy");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
            /*rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;*/

            //Mario Style Method
            //Destroy(col.transform.gameObject);


        }
        /*
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        */
        /*
        if (col.gameObject.tag == "enemy")
        {
            isDead = true;
        }
        */

    }

    void Animate()
    {
        anim.SetBool("IsMoving", (Input.GetButton("Horizontal")));
        anim.SetBool("IsCrouching", Input.GetKey("down"));
        anim.SetBool("IsGrounded", isGrounded);
        if (Input.GetKeyDown("z")){ Slide(); };
    }

    /*void PlayerRaycast()
    {
        //TODO fix this nasty code too
        //Ray UP
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < 0.9f && rayUp.collider.tag == "box_2")
        {
            //Debug.Log("Hit box");
            Destroy(rayUp.collider.gameObject);
        }


            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag == "enemy")
        {
            //Debug.Log("Squished enemy");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;
            //Destroy(hit.collider.gameObject);
        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < 1f && rayDown.collider.tag != "enemy")
        {
            isGrounded = true;
        }
    }*/
}
