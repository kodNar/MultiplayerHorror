using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;

    public static RaycastHit whatItHit; // se till att ta bort efter viss tid.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.red);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatItHit, distanceToSee)) //tar collidern för förmålet vår raycast träffade och lagrar den i "WhatItHit" variabeln.
        {
            Debug.Log("I touched "+whatItHit.collider.gameObject.name);
            //Destroy(whatItHit.collider.gameObject);
        }
    }
}
