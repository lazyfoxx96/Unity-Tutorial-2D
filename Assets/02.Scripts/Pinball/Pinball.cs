using System.Net.Sockets;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    public PinballManager pinballManager; // 유니티 상에서 할당 필요

    //충돌 이벤트
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int score = 0;
        //                       tag = 문자열확인 case와 비교
        switch(collision.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score30":
                score = 30;
                break;
            case "Score50":
                score = 50;
                break;
        }

        pinballManager.totalScore += score;
        if(score != 0)
        {
            Debug.Log($"{score}점 획득");
        }

        //if (collision.gameObject.CompareTag("Score10"))
        //{
        //    pinballManager.totalScore += 10;
        //    Debug.Log("10점 획득");
        //}
        //else if (collision.gameObject.CompareTag("Score30"))
        //{
        //    pinballManager.totalScore += 30;
        //    Debug.Log("30점 획득");
        //}
        //else if (collision.gameObject.CompareTag("Score50"))
        //{
        //    pinballManager.totalScore += 50;
        //    Debug.Log("50점 획득");
        //}

    }

    //감지 이벤트
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameOver"))
        {

            Debug.Log($"점수 : {pinballManager.totalScore}");
            Debug.Log("게임 종료");
        }
    }
}
