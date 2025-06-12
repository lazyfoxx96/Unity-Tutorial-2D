using UnityEngine;
using Cat;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using System.Collections;

public class CatController : MonoBehaviour
{
    /// <summary>
    /// Cat오브젝트에 스크립트를 넣고
    /// Rigidbody2D 타입을 만들어 GetComponent로 cat의 rigidbody를 가져옴
    /// </summary>

    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;

    //public GameObject happyVideo;
    //public GameObject sadVideo;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public bool isGround = false;

    public int jumpCount = 0;

    public float jumpPower = 10f;
    public float limitPower = 20f;

    //1번만 실행
    void Awake()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        transform.localPosition = new Vector3 (-6.4f, -1.3f, 0f);
        GetComponent<CircleCollider2D>().enabled = true;
        soundManager.audioSource.mute = false;
    }
    void Update()
    {
        Jump();
    }

    private void Jump()
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
                fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.white, true); //fadeRoutine에 접근해서 onFade함수 호출 

                this.GetComponent<CircleCollider2D>().enabled = false;

                //Invoke("HappyVideo", 5f);

                StartCoroutine(EndingRoutine(true));
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
            fadeUI.GetComponent<FadeRoutine>().OnFade(3f, Color.black, true); //fadeRoutine에 접근해서 onFade함수 호출

            this.GetComponent<CircleCollider2D>().enabled = false;
            
            //Invoke("SadVideo", 5f);

            StartCoroutine(EndingRoutine(false));
            //GameManager.isPlay = false;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("isGround", true);
            jumpCount = 0;
            isGround = true;
        }
    }

    IEnumerator EndingRoutine(bool isHappy)
    {
        //뒤에 적힌 값만큼 대기
        yield return new WaitForSeconds(3.5f);
        // PLAY 그룹 오브젝트 OFF
        

        videoManager.VideoPlay(isHappy);
        yield return new WaitForSeconds(1f);

        //var newColor = isHappy ? Color.white : Color.black;
        //fadeUI.GetComponent<FadeRoutine>().OnFade(3f, newColor, true);

        //yield return new WaitForSeconds(3f);
        //yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);
        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;

        transform.parent.gameObject.SetActive(false);
    }




    /*
    private void HappyVideo()
    {
        //happyVideo.SetActive(true);
        videoManager.VideoPlay(true);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameManager.isPlay = false;

        soundManager.audioSource.mute = true;
    }

    private void SadVideo()
    {
        //sadVideo.SetActive(true);
        videoManager.VideoPlay(false);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        GameManager.isPlay = false;

        soundManager.audioSource.mute = true;
    }
    */

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGround = false;
    //    }
    //}
}
