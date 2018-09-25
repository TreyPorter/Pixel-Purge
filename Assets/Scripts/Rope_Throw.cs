using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Throw : MonoBehaviour {

    public GameObject rope;

    GameObject currentRope;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentRope = (GameObject)Instantiate(rope, transform.position, Quaternion.identity);
            currentRope.GetComponent<Rope>().dest = dest;

        }
	}
}
