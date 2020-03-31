using System;
using System.Collections;
using System.Collections.Generic;
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
        Debug.Log(other.gameObject.tag+" klev på");
        if (other.gameObject.CompareTag("Player"))
        {
            platformAnimator.Play("enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.tag+" gick av");
        if (other.gameObject.CompareTag("Player"))
        {
            platformAnimator.Play("exit");
        }
    }
}