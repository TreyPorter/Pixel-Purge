using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour {
    GameObject curWeapon;
    GameObject Player;
    float af;

	// Use this for initialization
	void Start () {
        Player = transform.root.gameObject;
        curWeapon = Player.GetComponent<Player_Move_Prot>().cur;
        af = 0;
    }
	
	// Update is called once per frame
	void Update () {
        curWeapon = Player.GetComponent<Player_Move_Prot>().cur;
        if (af > 0) { af -= 1; }
        if (af <= 0) { curWeapon.GetComponent<Hitbox>().hitActive = false; }
    }

    void activateHitbox()
    {
        curWeapon.GetComponent<Hitbox>().hitActive = true;
        if (Player.GetComponent<Player_Move_Prot>().curWeapon == 1) { af = 35; }
        if (Player.GetComponent<Player_Move_Prot>().curWeapon == 2) { af = 35; }
        if (Player.GetComponent<Player_Move_Prot>().curWeapon == 3) { af = 25; }
    }

    void deactivateHitbox()
    {
        curWeapon.GetComponent<Hitbox>().hitActive = false;
    }
   
}
