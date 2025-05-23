using Mono.Cecil.Cil;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public Transform targetPlanet;

    public float rotSpeed = 30f; // 자전 속도

    public float revolutionSpeed = 100f; // 공전 속도

    public bool isRevolution = false;

    void Update()
    {
        //자기 자신이 회전하는 기능
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);

        if (isRevolution == true)
        {
            //공전하는 기능
            //                        어떤 대상 목표(Vector3)        회전축(Vector3)          속도(float)
            transform.RotateAround(targetPlanet.position, Vector3.up, revolutionSpeed * Time.deltaTime);
        }
    }
}
