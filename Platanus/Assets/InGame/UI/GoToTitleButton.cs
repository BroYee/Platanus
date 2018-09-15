using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        // GoToTiTle
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
