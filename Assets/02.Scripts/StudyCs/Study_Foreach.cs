using UnityEngine;

public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5] { "철수", "영희", "동수", "마이클", "존" };

    public string findName;

    void Start()
    {
        FindPerson(findName);
    }

    private void FindPerson(string name)
    {
        bool isFind = false;
        //스트링 타입의 배열 >> in 안으로 << person은 지역변수 in안의 변수들을 차례대로 지역변수에 넣음
        //var는 타입추론형
        foreach (var person in persons)
        {
            if (person == name)
            {
                isFind = true;
                Debug.Log($"인원 중에 {name}이 존재합니다.");
            }
        }

        if (!isFind)
            Debug.Log($"{name}을 찾지 못했습니다.");
    }
}
