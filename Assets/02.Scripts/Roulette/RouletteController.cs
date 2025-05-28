using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed;

    public bool isStop;

    private void Start()
    {
        rotSpeed = 0f;        
    }

    void Update()
    {
        //Z축을 기준으로 회전하는 기능
        transform.Rotate(Vector3.forward * rotSpeed);
        //transform.Rotate(0f, 0f, rotSpeed);

        //Vector3.forward = new Vector3(0f, 0f, 1f);

        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ㅇㅅㅇ");
            isStop = true;
        }

        if (isStop == true)
        {
            //점점 속도를 줄임 2%씩
            rotSpeed *= 0.98f; //현재 속도에서 특정 값만큼 줄이는 기능

            if (rotSpeed < 0.1f)
            {
                rotSpeed = 0f;
                isStop = false;
            }
        }
        
    }
}
