using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Introduce un retardo en el arranque de la animación
/// </summary>
public class InicializadorAnimaciones : MonoBehaviour
{
    Animator animator;
    [Range(0,1)]
    [Tooltip("El tiempo está normalizado - Entre 0 y 1 -")]
    public float delay;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("SubeBaja", 0, delay);//Layer 0, tiempo de espera antes de comenzar
        animator.speed = 1f;
    }

    public int GetSalario(float pct, int nivel, string categoria) 
    {
        return 0;
    }

}
