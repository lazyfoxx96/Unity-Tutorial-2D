using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Study_Switch : MonoBehaviour
{
    public enum CalculationType { PLUS, MINUS, MUILTIPLY, DIVIDE }
    public CalculationType calculationType;

    public int input1, input2, result;

    private void Start()
    {
        result = Calculation();
        Debug.Log($"계산 결과 : {result}");
    }

    private int Calculation()
    {
        switch(calculationType)
        {
            case CalculationType.PLUS:
                result = input1 + input2;
                break;
            case CalculationType.MINUS:
                result = input1 - input2;
                break;
            case CalculationType.MUILTIPLY:
                result = input1 * input2;
                break;
            case CalculationType.DIVIDE:
                result = input1 / input2;
                break;
        }

        return result ;
    }
}
