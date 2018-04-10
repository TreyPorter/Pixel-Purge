using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy_Move : MonoBehaviour {

    public GameObject Player;
    Player_Health playerHealth;
    public int EnemySpeed;
    public int XMoveDirection;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    RaycastHit2D hit;
    private Transform target;
    public LayerMask blockingLayer;         //Layer on which collision will be checked.
    public int enemyDamage;

    public bool jumper;
    private bool isGrounded;
    public int jumpPower;

	// Use this for initialization
	void Start () {
       target = Player.transform;
       //Get a component reference to this object's BoxCollider2D
       boxCollider = GetComponent <BoxCollider2D> ();
       //Get a component reference to this object's Rigidbody2D
       rb2D = GetComponent <Rigidbody2D> ();

       playerHealth = Player.GetComponent<Player_Health> ();
       isGrounded = false;
       if(jumper) {
           StartCoroutine(Jump());
       }
    }


    // Update is called once per frame
    void Update () {

        MoveEnemy<MonoBehaviour>();
        /* Bounce back and forth AI
        hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0), 0.7f);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if(hit.collider != null)
        {
            if (hit.collider.tag != "weapon") { Flip(); }
            if(hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject); // Destroys objects it touches
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //Destroy(hit.collider.gameObject); // Destroys objec

            ts it touches
        }
        */

        /*
        //TODO you should clean this nasty code up
        if(gameObject.transform.position.y < -50)
        {
            Destroy(gameObject);
        }
        */

	}

    public void MoveEnemy<T>() {
        int xDir = 0;
        int yDir = 0;
        if(Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon) {
            yDir = target.position.y > transform.position.y ? 1: -1;
        }
        else {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }
        //Debug.Log("Enemy headed to " + xDir + ", " + yDir);
        RaycastHit2D hit;
        bool canMove = Move (xDir, yDir, out hit);
        //Check if nothing was hit by linecast
        if(hit.transform == null) {
           //If nothing was hit, return and don't execute further code.
           return;
        }
        //Get a component reference to the component of type T attached to the object that was hit
        T hitComponent = hit.transform.GetComponent <T> ();
        //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
        if(!canMove && hitComponent != null) {
           //Call the OnCantMove function and pass it hitComponent as a parameter.
           OnCantMove (hitComponent);
        }
    }

    //Move returns true if it is able to move and false if not.
    //Move takes parameters for x direction, y direction and a RaycastHit2D to check collision.
    private bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;
        //Debug.Log("Enemy at " + start);
        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2 (xDir, yDir);
        //Debug.Log("Enemy headed to " + end);
        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        boxCollider.enabled = false;
        //Cast a line from start point to end point checking collision on blockingLayer.
        hit = Physics2D.Linecast (start, end, blockingLayer);
        //Re-enable boxCollider after linecast
        boxCollider.enabled = true;
        //Check if anything was hit
        if(hit.transform == null)
        {
            //Debug.Log("Starting Corotouine");
            //If nothing was hit
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, EnemySpeed * Time.deltaTime);
            rb2D.MovePosition (newPostion);
            //StartCoroutine (SmoothMovement (end));
            //Return true to say that Move was successful
            return true;
        }
        //If something was hit, return false, Move was unsuccesful.
        //Debug.Log("Can't Move ");
        return false;
    }
    //Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
    private IEnumerator SmoothMovement (Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter.
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            //Debug.Log("Time.deltaTime " + Time.deltaTime);
            //Debug.Log("EnemySpeed " + EnemySpeed);
            //Debug.Log("maxDistanceDelta " + (1/(float)EnemySpeed) * Time.deltaTime);
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, EnemySpeed * Time.deltaTime);
            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition (newPostion);
            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            Debug.Log("Enemy headed to " + end);
            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            //Debug.Log("RemainingDistance " + sqrRemainingDistance + ", " + float.Epsilon);
            yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Attacking");
            attackPlayer();
        }
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown != null && rayDown.collider != null && trig.collider.tag != "Player")
        {
            isGrounded = true;
            //anim.SetTrigger("Land");
            //anim.SetBool("IsGrounded", isGrounded);
        }
    }
    //OnCantMove is called if Enemy attempts to move into a space occupied by a target
    //and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case target
    private void OnCantMove <T> (T component)
    {
        /*
        if (component.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Attacking");
            attack();
        }
        */
    }
    IEnumerator Jump() {
        // JUMPING CODE
        bool continueCoroutine = true;
        while(continueCoroutine) { //variable that enables you to kill routine
            if (isGrounded) {
                GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpPower);
                isGrounded = false;
                //anim.SetTrigger("Jump");
                //anim.SetBool("IsGrounded", isGrounded);
            }
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Starting jump routine");
    }
    private void attackPlayer() {
        playerHealth.health = playerHealth.health - enemyDamage;
        Debug.Log("Player Health: " + playerHealth.health);
    }
    void Flip ()
    {
        if( XMoveDirection > 0)
        {
            XMoveDirection = -1;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
        else
        {
            XMoveDirection = 1;
            Vector2 localScale = gameObject.transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
