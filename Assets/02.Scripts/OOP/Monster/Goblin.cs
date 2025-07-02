using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Goblin : MonsterCore
{
    private float timer;
    private float idelTime, patrolTime;
    private float traceDist = 5f;
    private float attackDist = 1.5f;

    private bool isAttack;

    private void Start()
    {
        Init(30f, 3f, 2f, 10f);

        StartCoroutine(FindPlayerRoutine());
    }

    protected override void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        base.Init(hp, speed, attackTime, atkDamage);

        idelTime = Random.Range(1f, 5f);

    }

    IEnumerator FindPlayerRoutine()
    {
        while(true)
        {
            yield return null;
            targetDist = Vector3.Distance(transform.position, target.position);

            if (monsterState == MonsterState.IDLE || monsterState == MonsterState.PATROL)
            {
                // 몬스터가 바라보는 방향
                var monsterDir = Vector3.right * moveDir;
                //                    몬스터               플레이어 -> 플레이어가 몬스터를 바라보는 방향
                var playerDir = (transform.position - target.position).normalized;
                float dotValue = Vector3.Dot(monsterDir, playerDir);
                isTrace = dotValue < -0.8f && dotValue >= -1f;

                if (targetDist <= traceDist && isTrace)
                {
                    animator.SetBool("isRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            }
            else if (monsterState == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idelTime = Random.Range(1f, 5f);
                    animator.SetBool("isRun", false);
                    ChangeState(MonsterState.IDLE);
                }

                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if(timer >= idelTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            hpBar.transform.localScale = new Vector3(moveDir, 1, 1);

            patrolTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", true);

            ChangeState(MonsterState.PATROL);
        }
    }
    
    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if ( timer >= patrolTime)
        {
            timer = 0f;
            idelTime = Random.Range(1f, 5f);
            animator.SetBool("isRun", false);

            ChangeState(MonsterState.IDLE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized;
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime;

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);

        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);
    }

    public override void Attack()
    {
        if (!isAttack)
            StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        animator.SetTrigger("Attack");
        float currAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(currAnimLength);

        animator.SetBool("isRun", false);
        var targetDir = (target.position - transform.position).normalized;
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1);

        yield return new WaitForSeconds(attackTime - 1f);
        isAttack = false;
        animator.SetBool("isRun", true);
        ChangeState (MonsterState.TRACE);
    }
}