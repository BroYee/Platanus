using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleInfo : MonoBehaviour {

    public GameObject warning;

    public float fallingSpeed;

    private bool falling;

	// Use this for initialization
	void Start () {
        StartCoroutine(WarningAndFall());

        fallingSpeed = Random.Range(12.0f, 17.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (falling)
        {
            transform.Translate(0, -fallingSpeed * Time.deltaTime, 0);
        }
	}

    IEnumerator WarningAndFall()
    {
        Instantiate(warning, new Vector3(transform.position.x, 8, 0), Quaternion.identity);

        yield return new WaitForSeconds(2.0f);

        falling = true;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
            Time.timeScale = 0;
            Destroy(col);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
