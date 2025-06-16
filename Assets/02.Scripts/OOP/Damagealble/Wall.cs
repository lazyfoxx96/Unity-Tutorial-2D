using UnityEngine;

public class Wall : MonoBehaviour
{
    public void TakeDamage(float damage)
    {
        Debug.Log($"{damage}만큼의 피해를 입었습니다.");
    }
}
