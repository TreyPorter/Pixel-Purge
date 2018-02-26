using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;

	void Start () {
		
		PauseUI.SetActive(false); 

	}
	
	void Update () {
		
		if(Input.GetButtonDown("Pause")){
			paused =!paused;
		}

		if(paused){
			PauseUI.SetActive(true);
			Time.timeScale = 0;
		}

		if(!paused){
			PauseUI.SetActive(false);
			Time.timeScale = 1;
		}
	}

	/* ===============================================
	 *					WHATEVER
	 * ===============================================
	 */

	 public void Resume(){
	 	paused = false;
	 }

	 public void Restart(){
	 	//string scene = SceneManager.GetActiveScene.name();
	 	SceneManager.LoadScene(1);
	 	//Application.LoadLevel(Application.loadedLevel);
	 }

	 public void MainMenu(){
	 	SceneManager.LoadScene(0);
	 	//Application.LoadLevel(0); //Loads the level in Build Settings with Index of 1
	 }

	 public void Quit(){
	 	//Scene scene = SceneManager.GetActiveScene();
	 	//SceneManager.UnloadSceneAsync(scene.buildIndex);
	 	//SceneManager.Quit();
	 	//Application.Quit();
	 }
}
