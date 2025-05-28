using UnityEngine;

public class CatController : MonoBehaviour
{
    /// <summary>
    /// Cat오브젝트에 스크립트를 넣고
    /// Rigidbody2D 타입을 만들어 GetComponent로 cat의 rigidbody를 가져옴
    /// </summary>

    private Rigidbody2D catRb;
    public float jumpPower = 10f;

    public bool isGround = false;

    public int jumpCount = 0;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //스페이스 키 입력
        //                      (isGround) 같은거임 (isGround == true) -> 2단점프 방지
        //                                  jumpCount < 2 -> 2단 점프까지 허용
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) 
        {
            // 점프 = y축 방향을 이동 X
            // 힘을 가하는 방식을 택함
            //                       Impulse 순간적으로 힘을 가하는 방식
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
            isGround = true;
        }

        if(transform.rotation.z != 0f)
        {
           
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
