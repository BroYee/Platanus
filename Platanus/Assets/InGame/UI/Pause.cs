using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public bool pause = false;//일시정지를 하는 참거짓형 형태
    public void OnClickPause() {
        Debug.Log("Button Touch");
        pause = !pause;

        transform.parent.GetChild(2).gameObject.SetActive(pause);//부모자식관계로 부모의 '사용안함'상태를 '사용함'으로 변경함
    }
	
	
	void Update () {
        if (pause == true)//일시정지가 트루일때
        {
            Time.timeScale = 0;//시간을 멈춤
            Debug.Log("TimeStop");
        }
	}
}
