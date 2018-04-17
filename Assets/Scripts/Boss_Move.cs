using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class Boss_Move : MonoBehaviour {
/* Implemented from Brackey's Unity Tutorials: ENEMY AI Parts [1,2,3] */

	/* Variables/Objects */
		//Which object to chase?
		public Transform target;

		//How many times each second we will update our path
		public float updateRate = 2f;

		//Caching
		private Seeker seeker;
		private Rigidbody2D rb;

		//Reference to the calculated path
		public Path path;

		//Reference to AI's speed per second
		public float speed = 300f;
		public ForceMode2D fMode;

		[HideInInspector]
		public bool pathIsEnded = false;

		//Max distance from AI to a waypoint for it to continue to the next waypoint (lol)
		public float nextWaypointDistance = 3;

		//The waypoint we are currently moving towards
		private int currentWaypoint = 0;
		private Animator animator;

		public int bumpDamage;
		private bool attack2;
	void Start(){
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();

		if (target == null) {
			Debug.LogError ("No Player found? PANIC!");
			return;
		}
		animator = this.GetComponent<Animator> ();

		//Start a new path to the target position, return the result to the OnPathComplete function
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		//We want to update the path, but not every frame -> too much overhead
		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath(){
		if (target == null) {
			//TODO: Insert a player search here
			yield return false;
		}
		//Start a new path to the target position, return the result to the OnPathComplete function
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}

	public void OnPathComplete(Path p){
		Debug.Log ("We got a path. Did it have an error?" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	/* Fixed update rate, great for physics calculations, substitute for void Update() */
	void FixedUpdate(){
		if (target == null) {
			//TODO: Insert a player search here
			return;
		}

		//Debug.Log(target.position.x + ", " + transform.position.x);
		Vector2 localScale = gameObject.transform.localScale;
		if((target.position.x < transform.position.x && localScale.x > 0) || (target.position.x > transform.position.x && localScale.x < 0)) {
			//Debug.Log(target.position.x + ", " + transform.position.x);
			//Vector2 localScale = gameObject.transform.localScale;
			StartCoroutine(TurnAround(localScale));
		}
		if(target.position.y - transform.position.y >= 6) {
			if(!attack2) {
				animator.ResetTrigger ("walk");
				StartCoroutine(Attack_2());
			}
		}
		else if(target.position.x - transform.position.x >= -7 && target.position.x - transform.position.x <= 7 && localScale.x*(target.position.x - transform.position.x) >= 0) {//&& localScale.x > 0) {
			animator.SetTrigger("skill_1");
		}/*
		if (target.position.x - transform.position.x >= -7 && localScale.x < 0) {
			animator.SetTrigger("skill_1");
		}*/
		//special above boss attack
		if (path == null)
			return;

		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;

			Debug.Log ("End of path reached.");
			pathIsEnded = true;
			return;
		}

		pathIsEnded = false;

		//Next we need a direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized; //this gets the direction somehow
		dir *= speed * Time.fixedDeltaTime;

		//Move the AI
		rb.AddForce(dir, fMode);
		animator.SetTrigger("walk");
		//check if close enough to the next waypoint, if so, proceed next waypoint
		float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]); //check the 2nd parameter for this one
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}
	private void OnCollisionEnter2D(Collision2D trig)
	{
		if (trig.gameObject.tag == "Player")
		{
			Debug.Log("Boss Attacking");
			attackPlayer();
		}
	}
	private void attackPlayer() {
        Player_Health.reduceHealth(bumpDamage);
        Debug.Log("Player Health: " + Player_Health.health);
    }
	IEnumerator TurnAround(Vector2 localScale) {
		yield return new WaitForSeconds(4);
		localScale.x *= -1;
		transform.localScale = localScale;
	}
	IEnumerator Attack_2() {
		attack2 = true;
		//yield return new WaitForSeconds(3);
		animator.SetTrigger("skill_2");
		yield return new WaitForSeconds(1);
		GameObject boulder = GameObject.Find("boulder1");
		boulder.transform.position = new Vector3(target.position.x + 5, target.position.y + 10, 0);
		boulder.GetComponent<Rigidbody2D>().isKinematic = false;
		//boulder.transform.position.y = target.position.y + new Vector3(0,10;
		yield return new WaitForSeconds(.5f);
		boulder = GameObject.Find("boulder2");
		boulder.transform.position = new Vector3(target.position.x - 5, target.position.y + 10, 0);
		boulder.GetComponent<Rigidbody2D>().isKinematic = false;
		yield return new WaitForSeconds(.5f);
		boulder = GameObject.Find("boulder3");
		boulder.transform.position = new Vector3(target.position.x, target.position.y + 10, 0);
		boulder.GetComponent<Rigidbody2D>().isKinematic = false;
		yield return new WaitForSeconds(2);
		//yield return new WaitForSeconds(3);
		attack2 = false;
	}

}
