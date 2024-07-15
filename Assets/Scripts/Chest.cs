using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Spiller animasjon!");
            animator.SetTrigger("Open Chest");
        }
    }
}
