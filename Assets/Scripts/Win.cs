using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {
    // Update is called once per frame
    public string message;
    Enemy_Health script;
    private int BossHealth;
    public GameObject TextUI;
    public GameObject Exit_Door;
    public GameObject Exit_Text;
    void Start() {
        script = GameObject.Find("BOSS SKELE KNIGHT").GetComponent<Enemy_Health>();
        BossHealth = script.EnemyHealth;
        TextUI.gameObject.GetComponent<Text>().text = ("");
        Exit_Door = GameObject.Find("Exit");
        Exit_Door.SetActive(false);
        Exit_Text.SetActive(false);
    }
    void Update()
    {
        BossHealth = script.EnemyHealth;
        if (BossHealth <= 0)
        {
            TextUI.gameObject.GetComponent<Text>().text = (message);
            Exit_Door.SetActive(true);
            Exit_Text.SetActive(true);
        }
    }
}
