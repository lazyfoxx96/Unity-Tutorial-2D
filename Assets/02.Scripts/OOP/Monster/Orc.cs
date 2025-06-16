using UnityEngine;

public class Orc : Monster
{
    public float hp;
    public float moveSpeed;

    public void Move()
    {
        Debug.Log("Move");
    }

    public void Attack()
    {
        Debug.Log("Attack");
    }
}
