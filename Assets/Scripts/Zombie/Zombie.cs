using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Transform target;
    [SerializeField] private Transform playerCenterPos;
    [SerializeField] private Transform dumpPosition;
    [SerializeField] private ZombieDetection zombieDetection;
    [SerializeField] private Transform[] portalPoints;
    private Animator animator;
    private NavMeshAgent agent;
    private Vector3 lastedPlayerPosition = Vector3.zero;
    [SerializeField] private float zombieWalkSpeed = 1.4f;
    [SerializeField] private float zombieChaseSpeed = 6.16f;
    private bool isCloseToTarget;
    private bool isPlayScream;
    [SerializeField] private AudioSource screamAudioSource;
    [SerializeField] private AudioClip screamClip;
    public State state = State.wonder;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (target == null)
            target = GetPortalPoint();
    }

    // Update is called once per frame
    private void Update()
    {
        if (state == State.end)
        {
            agent.speed = 0f;
            animator.SetBool("IsPlayer", false);
            animator.SetBool("IsStop", false);
            Scream();
            return;
        }

        isCloseToTarget = CheckDistance();

        if (state == State.superchase)
        {
            Scream();
            agent.SetDestination(player.transform.position);
            agent.speed = 7.15f;
            animator.SetBool("IsPlayer", true);
            CheckCatchPlayer();
            return;
        }

        CheckCanSeePlayer();

        zombieDetection.isPlayerHide = GameManager.singletion.isPlayerHide;
        if (GameManager.singletion.isPlayerHide)
        {
            
            animator.SetBool("IsPlayer", false);
            agent.speed = zombieWalkSpeed;
            state = State.wonder;
        }
        if (state == State.wonder)
        {
            if (isCloseToTarget == true)
            {
                target = GetPortalPoint();
            }
        }
        else if (state == State.clueless)
        {
            agent.speed = zombieChaseSpeed;
            animator.SetBool("IsPlayer", true);
            if (isCloseToTarget == true)
            {
                state = State.wonder;

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
            Scream();
            state = State.chase;
            agent.speed = zombieChaseSpeed;
            animator.SetBool("IsPlayer", true);
            lastedPlayerPosition = player.transform.position;
            CheckCatchPlayer();
        }
        else
        {
            if (state == State.clueless)
                return;
            if (lastedPlayerPosition != Vector3.zero)
            {
                state = State.clueless;
                dumpPosition.position = lastedPlayerPosition;
                target = dumpPosition;
                lastedPlayerPosition = Vector3.zero;
                return;
            }
            isPlayScream = false;
            state = State.wonder;
            animator.SetBool("IsPlayer", false);
            agent.speed = zombieWalkSpeed;
        }
    }
    private void CheckCatchPlayer()
    {
        bool isNear = CheckDistance();
        if (isNear)
        {
            GameManager.singletion.EndGame("You died");
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
    private void Scream()
    {
        if (isPlayScream == false)
        {
            screamAudioSource.PlayOneShot(screamClip);
            isPlayScream = true;
        }
    }
    private Transform GetPortalPoint()
    {
        int r = Random.Range(0, portalPoints.Length);
        return portalPoints[r];
    }

    public enum State
    {
        wonder, chase, clueless , end , superchase
    }
}