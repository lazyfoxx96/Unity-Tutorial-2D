using System.Collections;
using UnityEngine;

public class Study_Coroutine : MonoBehaviour
{
    private Coroutine runningCoroutine;

    private bool isStop = false;

    private void Start()
    {
        //StartCoroutine("RoutineA");
        //runningCoroutine = StartCoroutine(RoutineA());

        //StopCoroutine(runningCoroutine);

        /*
        //호출 방식
        StartCoroutine("RoutineA");
        StartCoroutine(RoutineA());
        runningCoroutine = StartCoroutine(RoutineA());

        //Stop 방식
        StopCoroutine("RoutineA"); // O
        StopCoroutine(RoutineA()); // x
        StopCoroutine(runningCoroutine); // o
        StopAllCoroutines(); // o // 코드상에 있는 모든 코루틴 멈춤
        */

        //Invoke("StopMethodA", 3f);

        //StartCoroutine(RoutineA(10, 15, 20));
        StartCoroutine(BombRoutine());
    }

    //대기를 할 수 있는 기능
    IEnumerator RoutineA(int num1, int num2, int num3)
    {
        //필수 한개 프레임 대기
        yield return new WaitForSeconds(2f);
        Debug.Log(num1);

        yield return new WaitForSeconds(2f);
        Debug.Log(num2);

        yield return new WaitForSeconds(2f);
        Debug.Log(num3);

    }

    IEnumerator BombRoutine()
    {
        int t = 10;
        while (t>0)
        {
            Debug.Log($"{t}초 남았습니다.");
            yield return new WaitForSeconds(1f);
            t--;

            if(isStop)
            {
                Debug.Log("폭탄이 해제되었습니다.");
                yield break;
            }
        }

        Debug.Log("폭탄이 터졌습니다.");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isStop = true;
        }
    }

    void StopMethodA()
    {
        //StopCoroutine(RoutineA());
        //Debug.Log("asdasd");
    }
}

