using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour {

	public Image healthb;
    RectTransform healthbar;
    float origSize;
	private float maxhealth = 0;
    Animator GOanim;
    float delay;
    bool hitTrig;

	void Start () {
		healthbar = healthb.GetComponent<RectTransform>();
        origSize = healthbar.sizeDelta.x;
		maxhealth = FindObjectOfType<Player_Health>().maxhealth;
        GOanim = transform.Find("GameOverBack").GetComponent<Animator>();
        delay = 3;
        hitTrig = false;
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.sizeDelta = new Vector2(origSize * (Player_Health.health/maxhealth), healthbar.sizeDelta.y);
        if(Player_Health.health <= 0) { delay -= Time.deltaTime; }
        if(delay <= 0 && hitTrig == false) {GOanim.SetTrigger("GameOver"); hitTrig = true; }
	}
}
