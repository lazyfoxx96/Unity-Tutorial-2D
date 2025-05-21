using UnityEngine;

public class StudyComponent : MonoBehaviour
{
    //     데이터 타입
    
    private GameObject obj; // 큐브 게임오브젝트를 가져오고 싶다.

    public string changeName;

    // 유니티 실행시 1번 실행
    
    private void Start()
    {
        //Main Camera를 알아서 찾아서 가져오기때문에 GameObject를 public으로 굳이 설정하지않고
        //private으로 설정해 보이지않아도 변경이 되는걸 확인할 수 있다.
        obj = GameObject.Find("Main Camera");

        obj.name = changeName;        
    }
}
