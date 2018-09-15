using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour {

    public GameObject apple;

    public Transform playerTrans;

    public float minFallAppleDelay;
    public float maxFallAppleDelay;
    

	// Use this for initialization
	void Start () {
        StartCoroutine(FallApple());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FallApple()
    {
        yield return new WaitForSeconds(Random.Range(minFallAppleDelay, maxFallAppleDelay));
        minFallAppleDelay -= 0.1f;
        maxFallAppleDelay -= 0.1f;

        Debug.Log("Fall apple");

        Instantiate(apple, new Vector3(Random.Range(-5, 5), playerTrans.position.y + 100, 0), Quaternion.identity).transform.SetParent(transform);

        StartCoroutine(FallApple());
    }
}
