using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftAble : MonoBehaviour
{


    public GameObject item;

    public GameObject tempParent;

    public Transform hands;

    void Start()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        
        item.transform.position = hands.transform.position;
        item.transform.rotation = hands.transform.rotation;
        item.transform.parent = tempParent.transform;

    }

    private void OnMouseUp()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = hands.transform.position;
    }
}
