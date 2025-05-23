using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    //타켓을 하기위해선 transform을 추적하기때문에 변수도 transform타입으로 만들어주는게 나름 괜찮다.
    public Transform targetTf;
    public Transform turretHead;

    public GameObject bulletPrefab; // 총알 프리팹
    public Transform firePos; // 발사 위치

    public float timer;
    public float cooldownTime;

    void Start() // 무엇인가를 세팅하는 기능
    {
        //targetTf가 Transform타입이기때문에 마지막에 transform을 붙여준다.
        targetTf = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

    void Update() // 무언가를 바라보는 기능
    {
        turretHead.LookAt(targetTf);

        //타이머 기능
        timer += Time.deltaTime;
        //현재 타이머가 쿨다운 시간보다 커졌다면
        if(timer >= cooldownTime) 
        {
            //타이머는 계속 1초씩 늘어나고 cooldownTime에 도달했을때 타이머를 0으로 바꾸고 생성한다.
            timer = 0f;
            //생성함수 Instantiate 총알 생성
            //           생성 대상         생성 위치           회전상태
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
