using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour {

    public Transform playerTrans;

    private float highestPlayerYPos;

    // Use this for initialization
    void Start()
    {
        highestPlayerYPos = playerTrans.position.x;

        transform.position = playerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTrans.position.y >= highestPlayerYPos)
        {
            transform.position = Vector3.Lerp(new Vector3(0, transform.position.y, 0), new Vector3(0, playerTrans.position.y * -2, -10), Time.deltaTime);
            highestPlayerYPos = playerTrans.position.y;
        }
    }
}
