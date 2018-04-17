using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour {
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

        public float knockback;
        public float knockbackLength;
        private float knockbackCount;
        private bool knockFromRight;
    void Start(){
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();

		if (target == null) {
			Debug.LogError ("No Player found? PANIC!");
			return;
		}
        knockbackCount = 0;

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
    public void knockbackEnemy()
    {
        knockbackCount = knockbackLength;
        if (transform.position.x < target.position.x)
        {
            knockFromRight = true;
        }
        else
        {
            knockFromRight = false;
        }
    }
    /* Fixed update rate, great for physics calculations, substitute for void Update() */
    void FixedUpdate(){
		if (target == null) {
			//TODO: Insert a player search here
			return;
		}

		//TODO: Always look at player? (directional manipulation)

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
        if (knockbackCount <= 0)
        {
            rb.AddForce(dir, fMode);
        }
        else
        {
            if (knockFromRight)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }
		//check if close enough to the next waypoint, if so, proceed next waypoint
		float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]); //check the 2nd parameter for this one
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}
	}

}
