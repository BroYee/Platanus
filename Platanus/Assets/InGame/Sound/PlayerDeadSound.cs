﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadSound : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
