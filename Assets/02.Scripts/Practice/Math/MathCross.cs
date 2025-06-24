using UnityEngine;

public class MathCross : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    void Start()
    {
        // float result = Vector3.Dot(vecA, vecB); // Cos(theta) 값
        var result = Vector3.Cross(vecA, vecB); // 각도 값

        Debug.Log($"벡터 A와 벡터 B의 외적 : {result}");
    }
}

