using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MobileEnemy {

    [Range(1,50)]
    public float followDistance;

    public override void Update()
    {
        base.Update();//Ejecuta la implementación de Update de la clase base
        if (distanceToPlayer <= followDistance)
        {
            transform.LookAt(player.transform.position);
        }
        Move();
    }
    public override void Rotate()
    {
        if (distanceToPlayer <= followDistance) return;
        base.Rotate();
    }
}
