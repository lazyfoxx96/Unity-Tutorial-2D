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
        //부드럽게 증감하는 값 -1 ~ 1
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //딱 떨어지는 값 -1, 0, 1
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //                        x  y  z
        Vector3 dir = new Vector3(h, 0, v);
        //nomalized 1, 1, 0.71
        Vector3 normalDir = dir.normalized; // 정규화 과정 (0~1)

        //Debug.Log($"현재 입력 : {dir}");

        transform.position += normalDir * moveSpeed * Time.deltaTime;

        //회전 기능
        //      바라보는 기능   현재 위치         방향
        transform.LookAt(transform.position + normalDir);
    }
}
