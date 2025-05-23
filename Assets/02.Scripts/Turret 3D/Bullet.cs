using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 100f;

    void Update()
    {
        //                     vector3를 쓰게되면 월드상의 정면
        //transform.position += Vector3.forward * bulletSpeed * Time.deltaTime;
        //                     자기자신의 포워드
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
}
