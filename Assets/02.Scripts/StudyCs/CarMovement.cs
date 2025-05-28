using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;

    //성능에 따라 다른 프레임으로 실행되는 유니티 기본 함수
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        //Transform 이동
        //transform.position += Vector3.right * h * moveSpeed * Time.deltaTime;
    }

    // 고정 프레임으로 실행되는 유니티 함수
    private void FixedUpdate()
    {
        //물리연산이 많이 들어가는 코드들은 보통 FixedUpdate에서 실행한다

        //Rigidbody의 속도를 활용한 이동
        carRb.linearVelocityX = h * moveSpeed;

    }

    //붙을때 1번 실행
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        //collision.gameObject.SetActive(false);
        
        Debug.Log("Collision Enter");
    }

    //붙어있으면 계속 실행
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay");
    }
    
    //떨어질때 한번 실행
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Exit");
    }
}
