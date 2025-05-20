using Unity.VisualScripting;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    //멤버변수(필드)
    public int number1, number2;

    void Start()
    {
        int addResult = AddMethod(); // 함수 호출

        int minusResult = MinusMethod(); // 함수 호출

        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");
    }

    int AddMethod()
    {
        int result = number1 + number2;
        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;
        return result;
    }
}
