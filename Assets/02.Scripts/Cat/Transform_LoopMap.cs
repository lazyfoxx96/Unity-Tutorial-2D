using UnityEngine;

//public class Transform_LoopMap : MonoBehaviour
//{
//    public float moveSpeed = 3f;
//    //왼쪽으로 가던 배경이 돌아갈 위치
//    // 배경 이미지의 길이가 30이기 때문에 x = 30f
//    public Vector3 returnPos;

//    private void Start()
//    {
//        float posY = transform.position.y;
//        float posX = transform.position.x;
//        returnPos = new Vector3(25f, posY, 0f);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //배경 왼쪽으로 이동
//        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;
//        //fixedDeltaTime으로 변경
//        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
//        //Debug.Log(Time.deltaTime);

//        if(transform.position.x <= -returnPos.x)
//        {
//            transform.position = returnPos;
//        }

//    }
//}

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float returnPosX = 11f;
    public float randomPosY;
    
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= -returnPosX)
        {
            randomPosY = Random.Range(-8f, -2.5f);
            transform.position = new Vector3(returnPosX, randomPosY, 1);
        }
    }
}
