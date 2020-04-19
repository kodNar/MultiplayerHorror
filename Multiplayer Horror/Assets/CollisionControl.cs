using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        
    }
}
