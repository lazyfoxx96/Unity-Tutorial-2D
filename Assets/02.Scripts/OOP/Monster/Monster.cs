using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    public float hp;

    public abstract void SetHealth();

    void Start()
    {
        SetHealth();
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0f)
            Death();
    }

    public void Death()
    {
        Debug.Log("몬스터 죽음");
    }
}