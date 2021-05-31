using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public void CrearGas()
    {
        print("Creando gas...");
    }
    public void DarTortazo()
    {
        GameObject destinatario = GameObject.Find("Ramon");
        destinatario.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
    }
}
