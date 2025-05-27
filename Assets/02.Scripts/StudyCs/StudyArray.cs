


using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{
    //동적배열
    //public List<int> listNumber = new List<int>();











    //변수
    int number1 = 1;
    private int number2 = 2;
    public int number3 = 3;
    
    [SerializeField] //private
    private int number4 = 4;
    
    [SerializeField] int number5 = 5;

    void Start()
    {
        //listNumber.Add(12);
        //listNumber.Add(33);
        //listNumber.Add(42);
        //listNumber.Add(1);
        //listNumber.Add(67);

        //Debug.Log($"현재 List에 있는 데이터 수 : {listNumber.Count}");
        //Debug.Log($"현재 List에 있는 마지막 데이터 : {listNumber[listNumber.Count-1]}");
    }
}
