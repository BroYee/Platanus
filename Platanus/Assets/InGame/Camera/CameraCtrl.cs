using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {
    
    public Transform playerTrans;

    private float highestPlayerYPos;

	// Use this for initialization
	void Start () {
        highestPlayerYPos = playerTrans.position.x;

        transform.position = playerTrans.position;
    }
	
	// Update is called once per frame
	void Update () {

        if (playerTrans.position.y >= highestPlayerYPos)
        {
            transform.position = Vector3.Lerp(new Vector3(0, transform.position.y, 0), new Vector3(0, playerTrans.position.y, -10), 4.0f * Time.deltaTime);
            highestPlayerYPos = playerTrans.position.y;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
