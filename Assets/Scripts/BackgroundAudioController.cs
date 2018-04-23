using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioController : MonoBehaviour {
    public bool continueAudio;
    public int playAudio;
    public AudioSource currentAudio;
    int curAudio;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        currentAudio = transform.Find("1-MainMenu").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		//if(continueAudio == true) {  }
        if(curAudio != playAudio)
        {
            currentAudio.Stop();
            switch (playAudio)
            {
                case 1:
                    currentAudio = transform.Find("1-MainMenu").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
                case 2:
                    currentAudio = transform.Find("2-Home").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
                case 3:
                    currentAudio = transform.Find("3-Grass").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
                case 4:
                    currentAudio = transform.Find("4-Encounter").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
                case 5:
                    currentAudio = transform.Find("5-Town").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
                case 6:
                    currentAudio = transform.Find("6-Well").GetComponent<AudioSource>();
                    curAudio = playAudio;
                    break;
            }
            currentAudio.Play();
        }
	}
}
