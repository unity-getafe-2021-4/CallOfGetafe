using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float shootingRate;
    public int damage;
    public int magazine;//Capacidad de un cargador - Cada cargador tiene 10 balas
    public int maxAmmo;//Capacidad total - Puedo tener 50 balas
    public int currentAmmo;//Inventario de balas actual - Tengo 18 balas

    public abstract void TryShoot();
    public abstract void Shoot();

    public  void FailShoot()
    {
        //TODO. Programar qué hacer cuando no haya munición o no haya transcurrido el tiempo
    }
}
