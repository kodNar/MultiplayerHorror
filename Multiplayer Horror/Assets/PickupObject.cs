using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Camera _camera;
    private Boolean grounded;

    void Start()
    {
        _camera.GetComponent<Camera>();
    }

    void Update()
    {
    }


    public void tryLift()
    {
        Debug.Log("test1");

        if (Physics.Raycast(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward),
            out var whatItHit, 1000))
        {
            var hitGameObject = whatItHit.transform.gameObject;
            var tagName = hitGameObject.tag;
            var objectName = hitGameObject.name;
            Debug.Log("test2");
            if (tagName.Equals("LiftAble"))
            {
                if (!grounded)
                {
                    Debug.Log("test3");
                    hitGameObject.GetComponent<Rigidbody>().useGravity = false;
                    hitGameObject.GetComponent<Rigidbody>().isKinematic = true;
                    hitGameObject.transform.position = _camera.transform.position;
                    hitGameObject.transform.rotation = _camera.transform.rotation;
                    grounded = true;
                    return;
                }
                Debug.Log("test4");
                hitGameObject.GetComponent<Rigidbody>().useGravity = true;
                hitGameObject.GetComponent<Rigidbody>().isKinematic = false;
                hitGameObject.transform.position = _camera.transform.position;
                hitGameObject.transform.rotation = _camera.transform.rotation;
                grounded = false;
            }
        }
    }
}