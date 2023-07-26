using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ZombieDetection : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public bool isRayCastDetect;
    public bool isLos;

    public bool isCanSeePlayer;
    public bool isPlayerHide;
    // Update is called once per frame
    void Update()
    {
        if (isPlayerHide)
        {
            isRayCastDetect = false;
            isLos = false;
            isCanSeePlayer = false;
            return;
        }
           
        RayCastToPlayer();
        if (isRayCastDetect && isLos)
        {
            isCanSeePlayer = true;
        }
        else
        {
            isCanSeePlayer = false;
        }
    }
    private void RayCastToPlayer()
    {
        if (_player == null)
            return;

        RaycastHit hit;
        Debug.DrawRay(transform.position, _player.position - transform.position, Color.yellow);
        if (Physics.Raycast(transform.position, _player.position - transform.position, out hit, Mathf.Infinity))
        {
            // print(hit.transform.name);
            if (hit.transform.GetComponent<ThirdPersonController>())
            {
                isRayCastDetect = true;
            }
            else
            {
                isRayCastDetect = false;
            }

        }
        else
        {
            isRayCastDetect = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
        if (thirdPersonController != null)
        {
            isLos = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ThirdPersonController thirdPersonController = other.GetComponent<ThirdPersonController>();
        if (thirdPersonController != null)
        {
            isLos = false;
        }
    }
}
