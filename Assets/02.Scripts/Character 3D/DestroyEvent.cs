using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public float destroyTime = 3f;

    void Start()
    {
        //자기 자신을 3초 뒤에 파괴하는 기능
        Destroy(this.gameObject, destroyTime);
    }

    //파괴될 때 1번 실행됨
    void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}이 파괴되었습니다.");
    }

}
