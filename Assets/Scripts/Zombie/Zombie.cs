using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform target;
    [SerializeField] private Transform playerCenterPos;
    [SerializeField] private ZombieDetection zombieDetection;
    [SerializeField] private Transform[] portalPoints;
    private Animator animator;
    private NavMeshAgent agent;
    private bool isCloseToTarget;
    private State state = State.wonder;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (target==null)
            target = GetPortalPoint();    
    }

    // Update is called once per frame
    void Update()
    {
        isCloseToTarget = CheckDistance();
        CheckCanSeePlayer();

        if (state == State.wonder)
        {
            if (isCloseToTarget == true)
            {
                target = GetPortalPoint();
            }
            
        }
        else
        {
            target = player.transform;
        }

        agent.SetDestination(target.transform.position);
    }
    private void CheckCanSeePlayer()
    {
        if (zombieDetection.isCanSeePlayer)
        {
            state = State.chase;
            animator.SetBool("IsPlayer", true);
            agent.speed = 3;
        }
        else
        {
            state = State.wonder;
            animator.SetBool("IsPlayer", false);
            agent.speed = 1.2f;
        }
    }
    private bool CheckDistance()
    {
        Vector3 v = target.transform.position - transform.position;
        float dis = v.magnitude;
        if (dis < 1.2f)
        {
            animator.SetBool("IsStop", true);
            return true;
        }
        else
        {
            animator.SetBool("IsStop", false);
            return false;
        }
    }
    private Transform GetPortalPoint()
    {
        int r = Random.Range(0, portalPoints.Length);
        return portalPoints[r];
    }
    enum State
    {
        wonder,chase
    }
}
