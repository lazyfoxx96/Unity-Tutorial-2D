using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public <- 유니티 에디터 상에서 보이도록 설정
    public float moveSpeed = 10f;

    void Start()
    {

    }

    //this : 현재 스크립트가 들어가있는 오브젝트
    //this 빼도됨
    void Update()
    {
        //transform.position = transform.position + Vector3.forward * moveSpeed;
        //                      어몽어스 위치       앞쪽->(0,0,1)   속도 조절 변수
        if(Input.GetKey(KeyCode.W)) //앞으로
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) //뒤로
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) // 왼쪽으로
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) // 오른쪽으로
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
