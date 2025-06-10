using UnityEngine;

public class ColliderEvent : MonoBehaviour
{

    public GameObject fadeUI;

    /// <summary>
    /// 상호작용하는 둘 다 isTrigger = false일 경우 호출
    /// </summary>
    /// <param name="other"></param>
   void OnCollisionEnter(Collision other)
    {
        //충돌 + 감지
        //Debug.Log("Collision Enter");

    }

    /// <summary>
    /// 상호작용하는 둘 중 하나라도 isTrigger = true일 경우 호출 + 둘중 하나라도 rigidbody가 있어야함
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //감지
        //Debug.Log("Trigger Enter");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //fadeUI.SetActive(true);
            Debug.Log("Game Over");
        }
    }
}
