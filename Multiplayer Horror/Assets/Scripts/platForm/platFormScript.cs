using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Photon.Pun;
using UnityEngine;

public class platFormScript : MonoBehaviour
{
    private Animation platformAnimator;

    private void Start()
    {
        platformAnimator = GetComponent<Animation>();
    }
    
    [PunRPC]
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            platformAnimator.Play("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            platformAnimator.Play("exit");
        }
    }
    
}