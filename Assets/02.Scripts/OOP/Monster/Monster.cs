using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public SpawnManager spawner;

    private SpriteRenderer sRenderer;
    private Animator animator; 

    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;

    private int dir = 1;
    private bool isMove = true;
    private bool isHit = false;

    public abstract void Init();

    private void Start()
    {
        spawner = FindFirstObjectByType<SpawnManager>();

        sRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        Init();
    }

    private void OnMouseDown()
    {
        StartCoroutine(Hit(1));
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 몬스터가 오른쪽/왼쪽으로 이동하는 기능
    /// </summary>
    private void Move()
    {
        if (!isMove)
            return;
        
        transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            dir = -1;
            sRenderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            dir = 1;
            sRenderer.flipX = false;
        }
    }

    /// <summary>
    /// 몬스터가 공격 받았을때 로직
    /// </summary>
    /// <param name="damage"></param>
    /// <returns></returns>
    IEnumerator Hit(float damage)
    {
        if(isHit)
            yield break; // 현재 루틴 파괴

        isHit = true;
        isMove = false;

        hp -= damage;

        if(hp <= 0)
        {
            animator.SetTrigger("Death");

            spawner.DropCoin(transform.position);

            yield return new WaitForSeconds(3f);
            Destroy(gameObject);

            yield break;
        }

        animator.SetTrigger("Hit");

        yield return new WaitForSeconds(0.5f);
        isHit = false;
        isMove = true;
    }


}