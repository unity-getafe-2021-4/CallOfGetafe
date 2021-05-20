using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public GameObject prefabPSDamage;
    public GameObject prefabPSDeath;
    public float distanceToPlayer;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Error en Enemy buscando el elemento con el tag Player");
        }
    }

    public virtual void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    /// <summary>
    /// Determina si el player está a la vista o no
    /// </summary>
    /// <returns></returns>
    public bool PlayerDetected()
    {
        //TODO Programar si está viendo al Player
        return true;
    }


    /// <summary>
    /// Inflinge un daño al enemigo
    /// </summary>
    public void ReceiveDamage()
    {
        //TODO sistema de partículas, emitir un sonido, quitar salud, comprobar si ha muerto
    }

    /// <summary>
    /// Mata al enemigo
    /// </summary>
    public void Death()
    {
        //TODO sistema de partículas, emitir un sonido y destruir el objeto
    }

    /// <summary>
    /// Ataque del enemigo
    /// </summary>
    public abstract void Attack();
    
}
