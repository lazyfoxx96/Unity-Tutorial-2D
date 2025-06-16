using UnityEngine;

public class Monster : Character, IDamageable
{
    public float hp = 100f;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("몬스터 다운");
    }
}
 