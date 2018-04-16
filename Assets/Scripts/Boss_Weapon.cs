using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour {
    public bool hitActive;
	public int swordDamage;
    public GameObject sword;
    public float delay;
	// Use this for initialization
	void Start () {
        hitActive = false;
        sword.GetComponent<Boss_Weapon>().hitActive = false;
        delay = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
        if(delay > 0){delay -= 1;}
        if(delay <= 0){hitActive = false;
        sword.GetComponent<Boss_Weapon>().hitActive = false;}
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && hitActive == true)
        {
            if (collision.tag == "Player") {
				Player_Health.reduceHealth(swordDamage);
		        Debug.Log("Player Health: " + Player_Health.health);
            }
        }
    }
    void activateHitbox()
    {
        hitActive = true;
        sword.GetComponent<Boss_Weapon>().hitActive = true;
        sword.GetComponent<Boss_Weapon>().delay = 5;
        delay = 40;
    }

    void deactivateHitbox()
    {
        //hitActive = false;
    }
}
