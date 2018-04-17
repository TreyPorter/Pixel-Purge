using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingLeft = false;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    Animator anim;
    Animator armAnim;
    //GameObject Weapon;
    //Sprite curWeapon;
    public int curWeapon;
    float dashCD;
    public float dashPOW;
    bool disable; 

    public static int playerDamage;
    public int setPlayerDamage;

    public GameObject sword;
    public GameObject axe;
    public GameObject lance;
    public GameObject cur;

    public float knockback;
    public float knockbackLength;
    private float knockbackCount;
    private bool knockFromRight;
    // public bool isDead;

    //NPC talking, moved in NPC
    //public GameObject npcTextUI;
    //public NPC sample;

	//Ranged Weapon Addition
	public Transform firePoint;
	public GameObject projectile;

    // Use this for initialization
    void Start () {
        sword = transform.Find("Shoulder/ShoulderB/ArmB/ElbowB/HandB/Sword").gameObject;
        axe = transform.Find("Shoulder/ShoulderB/ArmB/ElbowB/HandB/Axe").gameObject;
        lance = transform.Find("Shoulder/ShoulderB/ArmB/ElbowB/HandB/Lance").gameObject;
        sword.SetActive(true);
        axe.SetActive(false);
        lance.SetActive(false);
        curWeapon = 1;
        cur = sword;
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", false);
        anim.SetBool("IsCrouching", false);
        anim.SetBool("IsGrounded", true);
        armAnim = transform.Find("Shoulder/ShoulderB").GetComponent<Animator>();
        armAnim.SetBool("IsAttacking", false);
        armAnim.SetBool("SwordActive", true);
        armAnim.SetBool("AxeActive", false);
        armAnim.SetBool("LanceActive", false);
        dashCD = 1;
        disable = false;


        playerDamage = setPlayerDamage;
        knockbackCount = 0;

    }


	// Update is called once per frame
	void FixedUpdate () {
        if(dashCD > 1) { dashCD -= 1; }
        if(dashCD < 1) { dashCD = 1; }
        if (Input.GetKeyDown("c") && dashCD == 1 && isGrounded == false) { dashCD = 10; }
        Attack();
        PlayerMove();
        //PlayerRaycast();
        Animate();

        //if(dashCD > 0) { dashCD -= Time.deltaTime; }
		  Ranged ();
    }

	void Ranged()
	{
		if (Input.GetButtonDown ("Shoot")) {
			Instantiate (projectile, firePoint.position, firePoint.rotation);
		}
	}
    void PlayerMove()
    {
        // CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true && disable == false)
        {
            Jump();
        }
        /*if (Input.GetKeyDown("c") && dashCD <= 0)
        {
            StartCoroutine(Dash());
        }*/
        // ANIMATIONS
        // PLAYER DIRECTION
        if (moveX < 0.0f && facingLeft == false && disable == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingLeft == true && disable == false)
        {
            FlipPlayer();
        }
        // PHYSICS
        /*if (disable == false)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    
        }*/
        if(knockbackCount <= 0 && disable == false) {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed * dashCD, gameObject.GetComponent<Rigidbody2D>().velocity.y + (dashCD - 1) * Input.GetAxis("Vertical"));
            //if(dashCD > 1) { gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, Input.GetAxis("Vertical") * dashCD * playerJumpPower); }
        }
        else {
            if(knockFromRight) {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            }
            if(!knockFromRight) {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }
    }
    void Jump()
    {
        // JUMPING CODE
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower * dashCD);
        isGrounded = false;
        anim.SetTrigger("Jump");
        anim.SetBool("IsGrounded", isGrounded);
    }

/*    IEnumerator Dash()
    {
        // DASH CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerJumpPower * moveX * playerSpeed * 100, ForceMode2D.Impulse);
        dashCD = 1;
        //isGrounded = false;
        anim.SetTrigger("Jump");
        yield return null;
        //anim.SetBool("IsGrounded", isGrounded);
    }*/

    void Attack()
    {
        if (Input.GetKeyDown("z") == true || Input.GetKey("z") == true) {
            //armAnim.SetBool("IsAttacking", true);
            armAnim.SetTrigger("Attack");

        }
        /*else {
            armAnim.SetBool("IsAttacking", false);
            //cur.GetComponent<Hitbox>().hitActive = false;
        }*/
        if (Input.GetKeyDown("x") == true) {weaponSwap();}

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
        //RaycastHit2D rayRight = Physics2D.Raycast(transform.position, Vector2.right);
        //RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, Vector2.left);
        if (rayDown != null && rayDown.collider != null && col.collider.tag != "enemy")
        {
            isGrounded = true;
            anim.SetTrigger("Land");
            anim.SetBool("IsGrounded", isGrounded);
        }
        if(col.collider.tag == "enemy" || col.collider.tag == "boss_weapon" || col.collider.tag == "boss" ) {
            if(col.collider.tag == "boss" || col.collider.tag == "boss_weapon") {
                Player_Health.health -= 5;
            }
            knockbackCount = knockbackLength;
            if (rayDown != null && rayDown.collider != null)
            {
                //Debug.Log("Squished enemy");
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300);
                Debug.Log("Player pushed up");
                /*rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
                rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
                rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;*/

                //Mario Style Method
                //Destroy(col.transform.gameObject);
            }
            if(transform.position.x < col.transform.position.x) {
                knockFromRight = true;
                /*
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                Debug.Log("Player pushed left");
                */
            }
            else {
                knockFromRight = false;
                /*
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100);
                Debug.Log("Player pushed rught");
                */
            }
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
        //if (Input.GetKeyDown("z")){ Attack(); };
    }

    void weaponSwap()
    {
        if(curWeapon == 0 || curWeapon == 3)
        {
            sword.SetActive(true);
            lance.SetActive(false);
            cur = sword;
            armAnim.SetBool("SwordActive", true);
            armAnim.SetBool("LanceActive", false);
            curWeapon = 1;
        }
        else if (curWeapon == 1)
        {
            axe.SetActive(true);
            sword.SetActive(false);
            cur = axe;
            armAnim.SetBool("AxeActive", true);
            armAnim.SetBool("SwordActive", false);
            curWeapon = 2;
        }
        else if (curWeapon == 2)
        {
            lance.SetActive(true);
            axe.SetActive(false);
            cur = lance;
            armAnim.SetBool("LanceActive", true);
            armAnim.SetBool("AxeActive", false);
            curWeapon = 3;
        }
    }

    public void Die()
    {
        disable = true;
        anim.SetTrigger("GameOver");
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
