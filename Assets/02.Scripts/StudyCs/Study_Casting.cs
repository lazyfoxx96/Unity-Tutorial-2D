using System;
using System.Collections.Generic;
using UnityEngine;

public class Study_Casting : MonoBehaviour
{
    private void Start()
    {
        // ========== INT → FLOAT ==========
        int intValue = 42;

        // 암시적 (자동 변환, 데이터 손실 없음)
        float result1 = intValue;
        Debug.Log($"int→float 암시적: {intValue} → {result1}");

        // 명시적 (의도 명확화)
        float result2 = (float)intValue;
        float result3 = Convert.ToSingle(intValue);
        Debug.Log($"int→float 명시적: {result2}, {result3}");


        // ========== FLOAT → INT ==========
        float floatValue = 42.7f;

        // 암시적 변환 불가능 (컴파일 에러)
        // int error = floatValue; // ❌ 에러!

        // 명시적 변환만 가능 (소수점 절삭, 데이터 손실 가능)
        int result4 = (int)floatValue;           // 42 (절삭)
        int result5 = Convert.ToInt32(floatValue); // 43 (반올림)
        int result6 = Mathf.FloorToInt(floatValue); // 42 (내림)
        int result7 = Mathf.CeilToInt(floatValue);  // 43 (올림)
        int result8 = Mathf.RoundToInt(floatValue); // 43 (반올림)

        Debug.Log($"float→int: {floatValue} → 캐스트:{result4}, Convert:{result5}");
        Debug.Log($"Mathf: Floor:{result6}, Ceil:{result7}, Round:{result8}");
    }
}
    
