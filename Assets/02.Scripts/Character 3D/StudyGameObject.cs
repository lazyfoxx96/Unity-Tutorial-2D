using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class StudyGameObject : MonoBehaviour
{
    public GameObject prefab;

    //public GameObject destroyObj;

    ////3차원 방향 0,0,0
    //public Vector3 pos;
    //// 0,0,0,1
    //public Quaternion rot;

    void Awake()
    {
        //Debug.Log("생성되었습니다.");
        CreateAmongus();

        //      파괴할 대상, 지연시간
        //Destroy(destroyObj, 3f); // 파괴하는 기능 <- 매개 변수로 들어간 게임 오브젝트를 파괴하는 기능
    }

    /// <summary>
    /// ////////start함수랑 같은 실행되는 함수!!!!!!!!!!!!!!!!!!
    /// 해당 오브젝트가 파괴될때도 실행됨
    /// </summary>
    //void OnDestroy()
    //{
    //    Debug.Log("파괴되었습니다.");
    //}

    /// <summary>
    ///  어몽어스 캐릭터를 생성하고 이름을 변경하는 기능
    ///  빨간색 Material을 적용한 어몽어스
    /// </summary>
    public void CreateAmongus()
    {
        //     생성할데이터, 위치, 회전
        //GameObject obj = Instantiate(prefab, pos, rot); // GameObject를 생성하는 기능

        //Instantiate(prefab, pos, rot).name = "어몽어스 캐릭터";
        //obj.name = "어몽어스 캐릭터";
        
        GameObject obj = Instantiate(prefab);
        obj.name = "어몽어스 캐릭터";

        //지역변수를 만들어서 담아서 쓰면 가독성 증가
        //지역변수는 함수가 종료되면 지역변수 삭제됨(메모리 해제)
        //Transform objTf = obj.transform;
        //int count = objTf.childCount;

        //Debug.Log($"캐릭터의 자식 오브젝트의 수 : {count}");

        //Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {objTf.GetChild(0).name}");

        //Debug.Log($"캐릭터의 첫번째 자식 오브젝트의 이름 : {objTf.GetChild(count - 1).name}");

        //자식의 자식의 마지막오브젝트
        //Debug.Log($"캐릭터의 마지막 자식 오브젝트의 자식의 마지막 오브젝트의 이름 : {objTf.GetChild(count - 1).GetChild(objTf.GetChild(count - 1).childCount - 1).name}");
    }
}
