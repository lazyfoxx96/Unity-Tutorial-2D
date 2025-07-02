using UnityEngine;
using UnityEngine.UI;

public class KnightController_Keyboard : MonoBehaviour, IDamageable
{
    private Animator animator;
    private Rigidbody2D knightRb;
    private Collider2D knightCol;
    [SerializeField] private Image hpBar;

    private Vector3 inputDir;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 13f;

    [SerializeField] private float atkDamage = 3f;

    [SerializeField] private float hp = 100f;
    [SerializeField] private float currHp;

    [SerializeField] private bool isGround;
    [SerializeField] private bool isAttack;
    [SerializeField] private bool isCombo;
    [SerializeField] private bool isLadder;

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        knightCol = GetComponent<Collider2D>();

        currHp = hp;
        hpBar.fillAmount = currHp / hp;
    }

    void Update() // 일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack();
    }

    void FixedUpdate() // 물리적인 작업
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                Debug.Log($"{atkDamage}로 공격");
                other.GetComponent<IDamageable>().TakeDamage(atkDamage);
            }
        }

        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0f;
            knightRb.linearVelocity = Vector2.zero;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f;
            knightRb.linearVelocity = Vector2.zero;
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if (inputDir.y < 0)
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 0.7f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.35f);
        }
        else
        { 
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 1.8f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.9f);
        }
    }

    void Move()
    {
        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            knightRb.linearVelocityX = inputDir.x * moveSpeed;
            //knightRb.linearVelocity = new Vector2(inputDir.x * moveSpeed, knightRb.linearVelocity.y);
        }

        if (isLadder)
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack)
            {
                isAttack = true;
                atkDamage = 3f;
                animator.SetTrigger("Attack");
            }
            else
                isCombo = true;
        }
            
    }

    public void CheckCombo()
    {
        if (isCombo)
        {
            atkDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            isAttack = false;
            animator.SetBool("isCombo", false);
        }
    }

    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;

        hpBar.fillAmount = currHp / hp;

        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        animator.SetTrigger("Death");
        knightCol.enabled = false;
        knightRb.gravityScale = 0;
    }
}
