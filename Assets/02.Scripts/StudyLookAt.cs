using UnityEngine;

public class StudyLookAt : MonoBehaviour
{
    //타켓을 하기위해선 transform을 추적하기때문에 변수도 transform타입으로 만들어주는게 나름 괜찮다.
    public Transform targetTf;
    public Transform turretHead;

    void Start() // 무엇인가를 세팅하는 기능
    {
        //targetTf가 Transform타입이기때문에 마지막에 transform을 붙여준다.
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() // 무언가를 바라보는 기능
    {
        
        turretHead.LookAt(targetTf);
    }
}
