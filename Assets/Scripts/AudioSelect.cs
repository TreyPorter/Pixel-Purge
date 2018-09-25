using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelect : MonoBehaviour {
    public int playAudio;

	// Use this for initialization
	void Start () {
        if(FindObjectOfType<BackgroundAudioController>()) {
            FindObjectOfType<BackgroundAudioController>().playAudio = playAudio;
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
