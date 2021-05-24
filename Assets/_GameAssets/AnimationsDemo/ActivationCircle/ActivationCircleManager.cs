using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationCircleManager : MonoBehaviour
{
    //Opci�n 1.
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", true);
        }
    }
    
}
