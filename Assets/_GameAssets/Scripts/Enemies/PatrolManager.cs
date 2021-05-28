using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManager : MonoBehaviour
{
    public float walkSpeed;//Velocidad de andar
    public float runSpeed;//Velocidad de correr
    public float runDistance;//Distancia a partir de la cual se pone a correr el AI
    public float idleTime=3;//Tiempo que está Axel esperando en un patrolPoint antes de continuar
    public bool isPlayerDetected = false;//Indica si ha detectado al player
    public bool randomRoute;//Indica si la ruta es aleatoria
    public Transform[] patrolPoints;//Puntos de la ruta
    private NavMeshAgent nma;//Sistema de navegación
    public int currentPoint = 0;//Indica el siguiente patrolPoint a seguir
    private Animator agentAnimator;//Animator controller
    private bool hasDestination = false;

    private void Awake()
    {
        nma = GetComponent<NavMeshAgent>();
        agentAnimator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        nma.SetDestination(patrolPoints[currentPoint].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (nma.remainingDistance <= nma.stoppingDistance)
        {
            if (!hasDestination)
            {
                agentAnimator.SetBool("Walk", false);
                Invoke("SetNewDestination", idleTime);
                hasDestination = true;
            }
        } else
        {
            if (nma.remainingDistance > runDistance)
            {
                agentAnimator.SetBool("Run", true);
                nma.speed = runSpeed;
            } else
            {
                agentAnimator.SetBool("Run", false);
                agentAnimator.SetBool("Walk", true);
                nma.speed = walkSpeed;
            }
        }
    }

    private void SetNewDestination()
    {
        hasDestination = false;
        currentPoint++;
        if (currentPoint == patrolPoints.Length) currentPoint = 0;
        if (randomRoute)
        {
            nma.SetDestination(patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position);
        }
        else
        {
            nma.SetDestination(patrolPoints[currentPoint].transform.position);
        }
    }
}
