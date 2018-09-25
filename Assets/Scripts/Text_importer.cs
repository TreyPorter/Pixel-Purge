using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_importer : MonoBehaviour {

    public TextAsset txtFile;
    public string[] txtLines;

	// Use this for initialization
	void Start () {

        if(txtFile != null)
        {
            txtLines = (txtFile.text.Split('\n'));

        }
		
	}
	
	// Update is called once per frame
	
}
