using JetBrains.Annotations;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public <- ����Ƽ ������ �󿡼� ���̵��� ����
    public float moveSpeed = 10f;

    void Start()
    {

    }

    //this : ���� ��ũ��Ʈ�� ���ִ� ������Ʈ
    //this ������
    void Update()
    {
        //transform.position = transform.position + Vector3.forward * moveSpeed;
        //                      ���� ��ġ       ����->(0,0,1)   �ӵ� ���� ����

        if(Input.GetKey(KeyCode.W)) //������
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) //�ڷ�
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) // ��������
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) // ����������
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
