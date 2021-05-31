using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class VisionDetector : MonoBehaviour
{
    [SerializeField] private GameObject visionDetectorAlarm;
    [SerializeField] private float detectionDistance;
    [SerializeField] private float visionAngle;
    [SerializeField] private Transform visionOrigin;
    [SerializeField] private LayerMask layerMask;

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = detectionDistance;
        GetComponent<SphereCollider>().isTrigger = true;
        visionAngle = visionAngle / 2;
    }
 
    private void OnTriggerStay(Collider other)
    {
        bool esElPlayer = other.gameObject.CompareTag("Player");
        bool estaEnAnguloYDistanciaVision = IsVisible(other.gameObject.transform.position);
        bool hasObtacle = HasObstacle(other.gameObject.transform.position);
        bool playerVisible =
            esElPlayer &&
            estaEnAnguloYDistanciaVision && 
            !hasObtacle;
        PlayerDetected(playerVisible, other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected(false, null);
        }
    }

    private void PlayerDetected(bool detected, GameObject target)
    {
        if (detected)
        {
            GetComponent<PatrolManager>().SetExternalDestination(target.transform.position);
        }
        visionDetectorAlarm.SetActive(detected);
    }

    private bool IsVisible(Vector3 playerPosition)
    {
        Vector3 targetDirection = (playerPosition - visionOrigin.position).normalized;
        Debug.DrawRay(visionOrigin.position, targetDirection, Color.red);
        //Debug.DrawRay(visionOrigin.position, visionOrigin.forward, Color.blue);
        if (Vector3.Angle(targetDirection, visionOrigin.forward)<= visionAngle)
        {
            return true;
        }
        return false;
    }

    private bool HasObstacle(Vector3 playerPosition)
    {
        Vector3 targetDirection = (playerPosition - visionOrigin.position).normalized;//Dirección del rayo
        Ray ray = new Ray(visionOrigin.position, targetDirection);//Rayo
        RaycastHit hitInfo;//Objeto que recoje los datos de la detección
        //bool hasObstacle = Physics.Raycast(ray, out hitInfo);//Lanzamiento del Raycast
        bool hasObstacle = Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerMask);
        if (hasObstacle) //Si ha detectado un Collider
        {
            if (hitInfo.collider.gameObject.CompareTag("Player"))//Es el player
            {
                return false;
            }
        }
        return true;//No es el player
    }

}
