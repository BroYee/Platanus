using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

    public float speed;
    
    void Start()
    {

    }

    void Update()
    {
        if (System.Math.Abs(transform.position.x) > 2)
        {
            speed *= -1;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
