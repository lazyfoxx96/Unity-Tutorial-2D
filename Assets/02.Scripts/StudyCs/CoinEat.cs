using UnityEngine;

public class CoinEat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Movement.coinCount++;
            Debug.Log($"현재까지 {Movement.coinCount}개의 코인 획득!!");
            Destroy(this.gameObject);
        }
    }
}
