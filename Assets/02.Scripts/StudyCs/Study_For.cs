using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Study_For : MonoBehaviour
{
    //public int[] arrayInt = new int[5];
    public List<int> listInt = new List<int>();

    private void Start()
    {
        //for(int i = 0; i < arrayInt.Length; i++)
        //{
        //    Debug.Log(arrayInt[i]);
        //}

        for (int i = 0; i < listInt.Count; i++)
        {
            Debug.Log(listInt[i]);
        }
    }
}
