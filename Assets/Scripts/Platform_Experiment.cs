using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Experiment : MonoBehaviour {
    Collider m_Collider;
    GameObject players;
    //players = GameObject.FindGameObjectWithTag("Player");

	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<Collider>();
        m_Collider.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		if(players.transform.position.y>=1.82)
        {
            m_Collider.enabled = true;
        }
        else
        {
            m_Collider.enabled = false;
        }
	}
}
