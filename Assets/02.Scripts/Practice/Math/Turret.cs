using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform turretHead;

    private float theta;
    public float rotSpeed = 1f;
    public float rotRange = 60f;

    private bool isTarget;
    public Transform target;

    void Update()
    {
        if(!isTarget)
        {
            TurretIdel();
        }
        else
        {
            TurretTarget();
        }
    }

    void TurretIdel()
    {
        theta += Time.deltaTime * rotSpeed;

        float rotY = Mathf.Sin(theta) * rotRange;

        turretHead.localRotation = Quaternion.Euler(0, rotY, 0);
    }

    void TurretTarget()
    {
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            target = other.transform;
            isTarget = true;
        }
    }
}
