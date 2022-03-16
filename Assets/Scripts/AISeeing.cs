using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISeeing : MonoBehaviour
{
    public Transform[] points;
    public Transform player;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public bool isPatrolling = true;

    public float radius = 20f;
    public float angle = 90f;
    private GameObject playerref;
    public LayerMask targetMask;
    public LayerMask ObstructionMask;

    public bool canSeePlayer;
    public bool isChasingPlayer = false;

    private AudioSource AudioSource;
    public AudioClip ambientSound;
    public float minWaitBetweenPlays = 14f;
    public float maxWaitBetweenPlays = 20f;
    public float waitTimeCountdown = -1f;
    public GameObject winMenu;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerref = GameObject.FindGameObjectWithTag("Player");
        AudioSource = GetComponent<AudioSource>();

        if (isPatrolling == true)
        {
            GotoNextPoint();

        }
        StartCoroutine(CheckForPlayer());
    }


    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && canSeePlayer == false && isChasingPlayer == false)
        {
            Patrolling();
        }
        if (canSeePlayer == true || isChasingPlayer == true)
        {
            Chasing();
        }
        if (playerref.GetComponent<PlayerController>().isLightOn == true)
        {
            radius = 40;
            angle = 180;
        }
        if (playerref.GetComponent<PlayerController>().isLightOn == false)
        {
            radius = 20;
            angle = 90;
        }
        //AmbientSounds();
        if (winMenu.activeInHierarchy)
        {
            AudioSource.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().CaughtByMonster();
        }
    }

    private IEnumerator CheckForPlayer()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, ObstructionMask))
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }

    private IEnumerator ChaseTimer()
    {
        isChasingPlayer = true;
        yield return new WaitForSeconds(2f);
        isChasingPlayer = false;
        isPatrolling = true;
    }
    private void Patrolling()
    {
        {
            agent.speed = 3f;
            GotoNextPoint();
        }
    }
    private void Chasing()
    {
        agent.speed = 7f;
        agent.SetDestination(player.position);
        StartCoroutine(ChaseTimer());

    }
    private void AmbientSounds()
    {
        if (waitTimeCountdown < 0f)
        {
            AudioSource.PlayClipAtPoint(ambientSound, transform.position);
            waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
        }
        else
        {
            waitTimeCountdown -= Time.deltaTime;
        }
    }
}