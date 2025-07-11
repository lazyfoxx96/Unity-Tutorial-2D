using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    public Animator anim;

    public GameObject doorLock;

    public string openKey;
    public string closeKey;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            doorLock.SetActive(true);
            //anim.SetTrigger(openKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorLock.SetActive(false);
            //anim.SetTrigger(closeKey);
        }
    }
}

