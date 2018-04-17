using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    // Update is called once per frame
    public string message;
    Enemy_Health script;
    public int BossHealth;
    public GameObject TextUI;
    void Start() {
        script = GameObject.Find("BOSS SKELE KNIGHT").GetComponent<Enemy_Health>();
        BossHealth = script.EnemyHealth;
        TextUI.gameObject.GetComponent<Text>().text = ("");
    }
    void Update()
    {
        BossHealth = script.EnemyHealth;
        if (BossHealth <= 0)
        {
            TextUI.gameObject.GetComponent<Text>().text = (message);
        }
    }
}
