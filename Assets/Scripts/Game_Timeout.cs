using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Timeout : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//StartCoroutine(EndGame());
	}

	// Update is called once per frame
	void Update () {

	}
	IEnumerator EndGame() {
		yield return new WaitForSeconds(30f);
		SceneManager.LoadScene(0);
	}

	public void MainMenu(){
	   Debug.Log("Main Menu pressed");
	   SceneManager.LoadScene(0);
	   //Application.LoadLevel(0); //Loads the level in Build Settings with Index of 1
	}

	public void Quit(){
	   Debug.Log("Quit pressed");
	   //Scene scene = SceneManager.GetActiveScene();
	   //SceneManager.UnloadSceneAsync(scene.buildIndex);
	   //SceneManager.Quit();
	   Application.Quit();
	}
}
