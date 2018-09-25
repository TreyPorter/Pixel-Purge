using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public Vector2 dest;
    public float speed = 1;
    public float distance = 2;
    public GameObject nodePrefab;
    public GameObject player;
    public GameObject lastNode;
    bool finish = false;

	// Use this for initialization
	internal void Start () {
        player = GameObject.FindGameObjectWithTag ("Player (1)");

        lastNode = transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, dest, speed);

        if((Vector2)transform.position != dest)
        {
            if (Vector2.Distance(player.transform.position, lastNode.transform.position) > distance)
            {
                CreateNode();
            }
        }
        else if (finish == false)
        {
            finish = true;
            lastNode.GetComponent<HingeJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();
        }


	}

    void CreateNode()
    {
        Vector2 pos2Create = player.transform.position - lastNode.transform.position;
        pos2Create.Normalize();
        pos2Create *= distance;
        pos2Create += (Vector2)lastNode.transform.position;

        GameObject go = (GameObject) Instantiate(nodePrefab, pos2Create, Quaternion.identity);

        go.transform.SetParent(transform);

        lastNode.GetComponent<HingeJoint2D>().connectedBody = go.GetComponent<Rigidbody2D>();

        lastNode = go;

    }
    
}
