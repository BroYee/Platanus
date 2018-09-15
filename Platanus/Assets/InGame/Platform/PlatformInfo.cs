using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfo : MonoBehaviour {
    private float prevPlayerHeight;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

        prevPlayerHeight = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.GetComponent<PlayerMove>().falling)
                StartCoroutine(col.gameObject.GetComponent<PlayerMove>().JumpAfterTime());
        }
    }
}
