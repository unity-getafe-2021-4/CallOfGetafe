using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobileEnemy : Enemy
{
    public float speed;
    public float timeToRotation;
    [Range(0, 360)]
    public float minAngle;
    [Range(0, 360)]
    public float maxAngle;
    [Range(1,5)]
    public float distanceToExplosion;
    private void Start()
    {
        InvokeRepeating("Rotate", timeToRotation, timeToRotation);
    }

    public override void Update()
    {
        base.Update();
        Attack();
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void Attack()
    {
        if (distanceToPlayer <= distanceToExplosion)
        {
            Instantiate(prefabPSDeath, transform.position, transform.rotation);
            //Alternativa triste
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Destroy(this);
            //Alternativa piadosa
            //Destroy(gameObject);
        }
    }

    public virtual void Rotate()
    {
        int determinante = Random.Range(0, 100);//Número entero entre 0 y 100
        int signo = determinante > 50 ? 1 : -1;//Expresión ternaria, tiene el mismo significado que el código siguiente
        /*
        if (determinante > 50)
        {
            signo = 1;
        } else
        {
            signo = -1;
        }
        */
        transform.Rotate(0, Random.Range(minAngle, maxAngle) * signo, 0);
    }
}
