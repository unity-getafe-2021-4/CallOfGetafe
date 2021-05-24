using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivationCircleManager : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Open", false);
        }
    }
}
