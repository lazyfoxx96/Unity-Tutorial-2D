using UnityEngine;
using Cat;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class CatController : MonoBehaviour
{
    /// <summary>
    /// Cat오브젝트에 스크립트를 넣고
    /// Rigidbody2D 타입을 만들어 GetComponent로 cat의 rigidbody를 가져옴
    /// </summary>

    public SoundManager soundManager;
    public GameObject gameOverUI;
    public GameObject fadeUI;

    public GameObject happyVideo;
    public GameObject sadVideo;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public bool isGround = false;

    public int jumpCount = 0;

    public float jumpPower = 10f;
    public float limitPower = 20f;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //스페이스 키 입력
        //                      (isGround) 같은거임 (isGround == true) -> 2단점프 방지
        //                                  jumpCount < 2 -> 2단 점프까지 허용
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 10)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("isGround", false);
            // 점프 = y축 방향을 이동 X
            // 힘을 가하는 방식을 택함
            //                       Impulse 순간적으로 힘을 가하는 방식
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();

            if (catRb.linearVelocityY > limitPower) // 자연스러운 점프를 위한 속도 제한
                catRb.linearVelocityY = limitPower;
        }

        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocity.y * 2.5f;
        transform.eulerAngles = catRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collision.gameObject.SetActive(false);
            collision.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            //사과 10개 먹고 성공
            if(GameManager.score == 10)
            {
                fadeUI.SetActive(true); //페이드 ui 켜기
                //성공페이드
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white); //fadeRoutine에 접근해서 onFade함수 호출 

                this.GetComponent<CircleCollider2D>().enabled = false;

                Invoke("HappyVideo", 5f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //파이프에 부딪혀서 실패
        if (collision.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();

            gameOverUI.SetActive(true); //게임오버 켜기
            fadeUI.SetActive(true); //페이드 ui 켜기
            //실패페이드
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black); //fadeRoutine에 접근해서 onFade함수 호출

            this.GetComponent<CircleCollider2D>().enabled = false;
            
            Invoke("SadVideo", 5f);
            //GameManager.isPlay = false;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
    }

    private void HappyVideo()
    {
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameManager.isPlay = false;
        happyVideo.SetActive(true);

        soundManager.audioSource.mute = true;
    }

    private void SadVideo()
    {
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameManager.isPlay = false;
        sadVideo.SetActive(true);

        soundManager.audioSource.mute = true;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = false;
    //    }
    //}
}
