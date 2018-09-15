using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    private void OnEnable()
    {
        GetComponent<UnityEngine.UI.Text>().text = transform.parent.parent.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>().text;
    }
}
