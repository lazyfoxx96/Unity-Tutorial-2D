using System;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //     게임오브젝트에 접근하지않고 바로 tag를 가져옴
        if(other.CompareTag("Player"))
        {   
            animator.SetTrigger("Open");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Close");
    
        }
    }
}