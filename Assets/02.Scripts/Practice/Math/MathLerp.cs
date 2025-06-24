using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    private Vector3 startPos;
    //            타이머  퍼센트   원하는 이동 시간
    private float timer, percent;
    public float lerpTime;

    private void Start()
    {
        startPos = transform.position; // 시작 지점 저장
    }

    private void Update()
    {
        timer += Time.deltaTime;
        percent = timer / lerpTime;

        //                              현재 위치           목표 위치       이동 비율
        transform.position = Vector3.Lerp(startPos, targetPos, percent);
    }
}
