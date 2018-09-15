using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatanusJump : MonoBehaviour {

    public float speed;

    private bool jumping;

    private void Start()
    {
        jumping = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            jumping = true;

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);

            StartCoroutine(StartGame());
        }

        if (jumping)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2.0f);
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
