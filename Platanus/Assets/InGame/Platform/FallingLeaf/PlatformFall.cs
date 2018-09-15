using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour {

    public float fallingSpeed;

    private bool stepped;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            stepped = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
            stepped = true;
    }


    // Update is called once per frame
    void Update () {
        if (stepped)
        transform.Translate(new Vector3(0, -fallingSpeed * Time.deltaTime, 0));
	}

    private void OnDisable()
    {
        stepped = false;
    }
}
