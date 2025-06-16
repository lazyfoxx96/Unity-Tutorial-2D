using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public float hp;
    public float speed;

    public abstract void Move();

    public virtual void Attack()
    {

    }

    public virtual void Talk()
    {

    }
}
