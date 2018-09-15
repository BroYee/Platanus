using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour {

    public float lifeTime;

	// Use this for initialization
	void Start () {
		
	}

    IEnumerator Live()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
