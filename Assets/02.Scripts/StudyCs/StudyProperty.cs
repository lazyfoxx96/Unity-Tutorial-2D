using Cat;
using UnityEngine;

public class StudyProperty : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 20f;

    private int number1 = 10;
    public int Number1
    {
        get { return number1; }
        set { number1 = value; }
    }

    public int Number2 { get; set; } = 20;

    //public int number2 = 20;

    //내/외부 접근 가능                //내부에서만 수정가능
    public int Number3 { get; private set; } = 30;

    private float hp = 100f;
    public float Hp
    {
        get { return hp; }
        //private set { hp = value; }
        set
        {
            if (value < 0)
            {
                hp = 0f;
                Death();
            }
            else
            {
                hp = value;
            }
        }
    }

    private SoundManager sound;
    public SoundManager Sound
    {
        get
        {
            if (sound == null)
                sound = FindFirstObjectByType<SoundManager>();

            return sound;
        }
    }

    public void Death()
    {

    }

    public void Hit(float damage)
    {
        Hp -= damage;
    }

    private void Start()
    {
        Number1 = 100;
        Number2 = 200;
        Number3 = 300;
    }
}
