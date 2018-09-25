﻿using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour
{

    public float speed = 6;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (other.gameObject.name == "Player" && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        }
        else
        {

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);

        }



    }
}
