using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D characterRb;
    public SpriteRenderer[] renderers;

    public GameObject[] renderObjs;

    public float moveSpeed;
    private float h;
    public float jumpPower = 10f;

    public bool isGround;

    void Start()
    {
        characterRb = GetComponent<Rigidbody2D>();

        //spriteRenderer를 가지고있는 자식들을 모두 가져와라
        //                               true를 넣으면 비활성화된 오브젝트도 모두 가져온다.
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); // 키 입력

        jump();
    }

    void FixedUpdate()
    {

        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;

        renderers[2].gameObject.SetActive(false); // Jump
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround= false;

        renderers[0].gameObject.SetActive(false); // Idle
        renderers[1].gameObject.SetActive(false); // Run
        renderers[2].gameObject.SetActive(true); // Jump
    }

    /// <summary>
    /// 캐릭터가 움직임에 따라 이미지의 filp 상태가 변하는 기능
    /// </summary>
    void Move()
    {
        if (!isGround) 
            return;

        if (h != 0) // 움직일 때
        {
            renderers[0].gameObject.SetActive(false); // Idle
            renderers[1].gameObject.SetActive(true); // Run

            characterRb.linearVelocityX = h * moveSpeed; // 물리적인 이동

            //filpx를 이용해 왼쪽 오른쪽 이동할때 향하는곳 바라보기
            if (h > 0)
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;
            }
            else if (h < 0)
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }

        }
        else // 움직이지않을때
        {
            renderers[0].gameObject.SetActive(true); // Idle
            renderers[1].gameObject.SetActive(false); // Run
        }
    }

    /// <summary>
    /// 캐릭터가 +Y 방향으로 점프하는 기능
    /// </summary>
    void jump()
    {
        //fixedUpdate()에 jump를 넣으니 잘 안눌림
        //물리적인 순간적인 힘
        if (Input.GetButtonDown("Jump")) // Input.GetKeyDown(KeyDown.Space)와 동일
        {
            characterRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}
