using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Health_Bar : MonoBehaviour {

	public Image healthb;
    RectTransform healthbar;
    float origSize;
	private float maxhealth = 0;

	void Start () {
		healthbar = healthb.GetComponent<RectTransform>();
        origSize = healthbar.sizeDelta.x;
		maxhealth = FindObjectOfType<Enemy_Health>().EnemyHealth;
	}

	// Update is called once per frame
	void Update () {
		healthbar.sizeDelta = new Vector2(origSize * (FindObjectOfType<Enemy_Health>().EnemyHealth / maxhealth), healthbar.sizeDelta.y);
		if(FindObjectOfType<Enemy_Health>().EnemyHealth <= 0) {
			Destroy(this.gameObject);
		}
	}
}
