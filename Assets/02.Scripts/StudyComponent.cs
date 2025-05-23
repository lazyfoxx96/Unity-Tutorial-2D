using UnityEngine;

//접근제한자 클래스 클래스명 : 상속(유니티의 유용한 기능이 들어있는 곳)
public class StudyComponent : MonoBehaviour
{
    //     데이터 타입
    //접근제한자 타입 변수명
    public GameObject obj; // 큐브 게임오브젝트를 가져오고 싶다.

    public Transform objTF;

    //public string changeName;

    // 유니티 실행시 1번 실행

    private void Start()
    {
        //Main Camera를 알아서 찾아서 가져오기때문에 GameObject를 public으로 굳이 설정하지않고
        //private으로 설정해 보이지않아도 변경이 되는걸 확인할 수 있다.
        //obj = GameObject.Find("Main Camera");

        //                       태그활용        태그명
        obj = GameObject.FindGameObjectWithTag("Player");

        //transform 타입으로 반환됨
        objTF = GameObject.FindGameObjectWithTag("Player").transform;

        objTF = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //obj = objTf.gameObject

        // transform은 항상 존재하기때문에 gameObject로 역으로 불러옴
        objTF.gameObject.SetActive(false);

        //GameObject : 데이터타입
        //gameObject : 변수

        //.transform
        //.gameObject

        //코드에서 찾는것으 목적은 보통 private 변수를 할당해주기위해 사용한다.

        //Debug.Log($"<color=#FF0000>이름 : {obj.name}</color>"); //게임오브젝트의 이름
        //Debug.Log($"<color=#00FF00>태그 : {obj.tag}</color>"); //게임오브젝트의 태그 
        //Debug.Log($"<color=#0000FF>위치 : {obj.transform.position}</color>"); //게임오브젝트의 Transform 컴포넌트의 위치
        //Debug.Log($"<color=#FFFF00>회전 : {obj.transform.rotation}</color>"); //게임오브젝트의 Transform 컴포넌트의 회전
        //Debug.Log($"<color=#FF00FF>크기 : {obj.transform.localScale}</color>"); //게임오브젝트의 Transform 컴포넌트의 크기

        // MeshFilter 컴포넌트에 접근해서 mesh데이터를 log메세지로 출력하는 기능
        //Debug.Log($"Mesh 데이터 : {obj.GetComponent<MeshFilter>().mesh}");

        // MeshRenderer 컴포넌트에 접근해서 material데이터를 log메세지로 출력하는 기능
        //Debug.Log($"Material 데이터 : {obj.GetComponent<MeshRenderer>().material}");

        //obj.name = changeName;

        //오브젝트가 보이지만 않게
        //obj의 MeshRenderer에 접근해 활성상태를 false로 변경
        obj.GetComponent<MeshRenderer>().enabled = false;

        //오브젝트를 비활성화
        //obj의 gameObject 활성상태를 false -> 끄는 기능
        obj.SetActive(false);





    }
}