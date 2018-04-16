using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour {

	public Image healthb;
    RectTransform healthbar;
    float origSize;
	private float maxhealth = 0;

	void Start () {
		healthbar = healthb.GetComponent<RectTransform>();
        origSize = healthbar.sizeDelta.x;
		maxhealth = FindObjectOfType<Player_Health>().maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthbar.sizeDelta = new Vector2(origSize * (Player_Health.health/maxhealth), healthbar.sizeDelta.y);
	}
}
