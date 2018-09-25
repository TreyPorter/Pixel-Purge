using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	public GameObject PauseUI;
	private bool paused = false;

	void Start () {
		if(PauseUI.transform.Find("Canvas"))
			PauseUI.transform.Find("Canvas").gameObject.SetActive(false);

	}

	void Update () {
		if(Input.GetButtonDown("Pause")){
			paused =!paused;
			Debug.Log("Game Pause");
		}

		if(paused){
			//Debug.Log("Pause pressed");
			if(PauseUI.transform.Find("Canvas")) {
				PauseUI.transform.Find("Canvas").gameObject.SetActive(true);
			}
			Time.timeScale = 0;
		}

		if(!paused){
			if(PauseUI.transform.Find("Canvas")) {
				PauseUI.transform.Find("Canvas").gameObject.SetActive(false);
			}
			Time.timeScale = 1;
		}
	}

	/* ===============================================
	 *					WHATEVER
	 * ===============================================
	 */

	 public void Resume(){
		Debug.Log("Resume pressed");
	 	paused = false;
	 }

	 public void Restart(){
	 	//string scene = SceneManager.GetActiveScene.name();
		Debug.Log("Restart pressed");
		Resume();
	 	Player_Health.health = 0;
	 	//Application.LoadLevel(Application.loadedLevel);
	 }

	 public void MainMenu(){
		Debug.Log("Main Menu pressed");
		if (FindObjectOfType<BackgroundAudioController>()) {
			Debug.Log("Audio Object Destroyed");
			FindObjectOfType<BackgroundAudioController>().currentAudio.Stop();
			Destroy(FindObjectOfType<BackgroundAudioController>());
		}
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
