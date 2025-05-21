using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StudyArray : MonoBehaviour
{
    //??덉읅獄쏄퀣肉?
    //public List<int> listNumber = new List<int>();

    //癰궰??
    int number1 = 1;
    private int number2 = 2;
    public int number3 = 3;
    
    [SerializeField] //private?쒖눘踰먲쭖??臾롫젏 癰귣똻釉??????誘???SerializeField???????곴퐣 ?醫롮뵬??띿쓺 ?醫딅빍?怨쀫퓠野껊슢彛???곷선餓Β椰꾧퀡?ゆ?癰귣????
    private int number4 = 4;
    
    [SerializeField] int number5 = 5;

    void Start()
    {
        //listNumber.Add(12);
        //listNumber.Add(33);
        //listNumber.Add(42);
        //listNumber.Add(1);
        //listNumber.Add(67);

        //Debug.Log($"?袁⑹삺 List????덈뮉 ?怨쀬뵠????: {listNumber.Count}");
        //Debug.Log($"?袁⑹삺 List????덈뮉 筌띾뜆?筌??怨쀬뵠????: {listNumber[listNumber.Count-1]}");
    }
}
