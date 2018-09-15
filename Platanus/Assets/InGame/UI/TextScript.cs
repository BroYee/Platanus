using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    private double _score = 0;//실시간으로 오르락내리락하는 자신의 높이
    double HighScore = 0;//자신이 올라간 높이 중, 가장 높은 높이
    //'전체적인 게임'에서의 하이스코어를 만들어야함, 스태틱?


    private double _min = 0;//점수의 최솟값
    public Transform PlayerTransform;//플레이어의 높이 상태를 이 스크립트에서 쓰기 위해서 만듬

    private void Start()
    {
        StartCoroutine(ChangeScore());
    }

    public void Add(double score)
    {
        _score += score;
    }

    public void Clear()
    {
        _score = 0;
    }

    private void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Score : " + HighScore.ToString();
        //Debug.Log(PlayerTransform.position.y);//플레이어의 위치를 확인하기위해 계속 출력

       
    }

        IEnumerator ChangeScore()
        {
            yield return new WaitForSeconds(0.1f);//0.1초마다 점수가 갱신되게 설정함.
            _score = System.Math.Round(PlayerTransform.position.y);//플레이어의 y축을 스코어에 연동
        //플레이어가 -8(반올림)에서 시작하는걸 감안하여 + 8을 하였고 double형이지만 반올림을 하였다.
        
        if (_score >= HighScore)//하이스코어보다 현재 점수가 높을시,
        {
            HighScore = _score;//하이스코어에 플레이어의 높이를 저장
            //Debug.Log("하이스코어 "+ HighScore);//하이스코어가 제대로 저장되는지 확인하기 위한 장치
        }
        StartCoroutine(ChangeScore());
        }
}
