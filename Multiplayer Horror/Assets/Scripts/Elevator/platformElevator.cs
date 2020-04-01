using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class platformElevator : MonoBehaviour
{
    private Animation elevatorAnimator;
    // Start is called before the first frame update
    private void Start()
    {
        elevatorAnimator = GetComponent<Animation>();
    }
    
    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorAnimator.Play("up");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elevatorAnimator.Play("down");
        }
    }
}
