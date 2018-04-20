using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		//technically index 1 = test environment
	}

	public void Button2()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		//index 2 = level prototype
	}
	public void Options()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
