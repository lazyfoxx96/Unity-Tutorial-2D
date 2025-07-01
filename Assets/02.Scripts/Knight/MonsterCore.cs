using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK };
    public MonsterState monsterState;

    protected Animator animator;
    protected Rigidbody2D monsterRb;
    protected Collider2D monsterColl;

    public Transform target; // -> PLAYER

    public float hp;
    public float speed;
    public float attackTime;

    protected float moveDir;
    protected bool isTrace;

    protected float targetDist;

    //생성자와 비슷한 용도
    protected virtual void Init(float hp, float speed, float attackTime)
    {
        this.hp = hp;
        this.speed = speed;
        this.attackTime = attackTime;

        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
        monsterRb = GetComponent<Rigidbody2D>();
        monsterColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);

        // 몬스터가 바라보는 방향
        var monsterDir = Vector3.right * moveDir;

        //                    몬스터               플레이어 -> 플레이어가 몬스터를 바라보는 방향
        var playerDir = (transform.position - target.position).normalized;

        float dotValue = Vector3.Dot(monsterDir, playerDir);

        isTrace = dotValue < -0.8f && dotValue >= -1f;

        switch (monsterState)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Return"))
        {
            moveDir *= -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }

    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();
    
    //디버깅에 유리
    //유지모수 유리
    public void ChangeState(MonsterState newState)
    {
        if (monsterState != newState)
            monsterState = newState;
    }
}
