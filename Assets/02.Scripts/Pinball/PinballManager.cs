using UnityEngine;

public class PinballManager : MonoBehaviour
{
    public Rigidbody2D leftBarRb;
    public Rigidbody2D rightBarRb;

    public int totalScore = 0;
    
    //AddTorque는 회전에 힘을 가함
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
            leftBarRb.AddTorque(50f);
        else
            leftBarRb.AddTorque(-45f);

        if(Input.GetKey(KeyCode.RightArrow))
            rightBarRb.AddTorque(-50f);
        else
            rightBarRb.AddTorque(45f);
    }
}
