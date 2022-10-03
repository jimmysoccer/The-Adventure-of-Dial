using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFanPlatform : MonoBehaviour
{
    //this is to make sure when the user is on the fan, then the fan starts to run

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // check if collsion
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.Play("Fan_run");
        }
    }
    // void Update()
    // {
        
    // }
}
