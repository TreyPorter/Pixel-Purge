using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour {
    GameObject curWeapon;
    GameObject Player;


	// Use this for initialization
	void Start () {
        Player = transform.root.gameObject;
        curWeapon = Player.GetComponent<Player_Move_Prot>().cur;
	}
	
	// Update is called once per frame
	void Update () {
        curWeapon = Player.GetComponent<Player_Move_Prot>().cur;
    }

    void activateHitbox()
    {
        curWeapon.GetComponent<Hitbox>().hitActive = true;
    }

    void deactivateHitbox()
    {
        curWeapon.GetComponent<Hitbox>().hitActive = false;
    }
   
}
