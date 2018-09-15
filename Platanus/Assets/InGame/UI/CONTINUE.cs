using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTINUE : MonoBehaviour {

    public void OnClickContinue()
    {
        Debug.Log("CONTINUE Button Click");
        Time.timeScale = 1;
        transform.parent.parent.GetChild(1).gameObject.GetComponent<Pause>().pause = false;//자식 1을 부른다.
        transform.parent.gameObject.SetActive(false);//부모를 부름으로써 자식들도 모두 불러진다, pause를 호출하지 않고 그냥 pause를 flase로 바꿔버린다.
    }
	void Start () {
		
	}

    void Update () {
		
	}
}
