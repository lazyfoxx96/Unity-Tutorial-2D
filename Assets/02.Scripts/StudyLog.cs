using System;
using UnityEngine;

//����Ƽ �����Ϳ� �ִ� Console View�� Log�� �׽�Ʈ�ϱ� ���� Ŭ����
public class StudyLog : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //�Լ� ȣ�� : Update()�����ϱ� ��, ���� �����Ѵ�. 
    //����Ƽ �⺻ �Լ�
    void Start()
    {
        Debug.Log("Start �Լ� ����"); // �Ϲ����� �α�
        Debug.LogWarning("Start �Լ� ����"); // ��� �α�
        Debug.LogError("Start �Լ� ����"); // ���� �α�
    }

    // Update is called once per frame
    //������Ʈ�� �����Ӹ��� �ѹ��� �����Ѵ�.
    //����Ƽ �⺻ �Լ�
    void Update()
    {
        //Debug.Log("Update �Լ� ����");
    }
}
