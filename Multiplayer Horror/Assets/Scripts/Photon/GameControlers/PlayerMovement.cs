using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks, IPunObservable

{
    private Vector2 mouseLook;
    public bool isGrounded;
    public float MouseSensitivity;
    public float MoveSpeed;
    private float JumpForce = 7f;
    private Light playerFlashLight;
    private Rigidbody Rigid;
    private Camera myCamera;
    private PhotonView PV;
    private bool flashLight = true;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Rigid = GetComponent<Rigidbody>();
        myCamera = GetComponentInChildren<Camera>();
        playerFlashLight = GetComponentInChildren<Light>();
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            myCamera.enabled = true;
        }
        else
        {
            myCamera.enabled = false;
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            // stream.SendNext(playerFlashLight.enabled);
            stream.SendNext(GameSetup.spawnCounter);
        }
        else if (stream.IsReading)
        {
            //Network read this, others see
            // playerFlashLight.enabled = (bool) stream.ReceiveNext();
            GameSetup.spawnCounter = (int) stream.ReceiveNext();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = myCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward),
                out var whatItHit, 1000))
            {
                if (whatItHit.transform.gameObject.CompareTag("Button"))
                {
                    var tempName = whatItHit.transform.gameObject.name;

                      whatItHit.transform.gameObject.GetComponentInParent<ButtonScript>().button_Pressed(tempName);
                    
                   // PV.RPC("button_Pressed",RpcTarget.All,tempName);
                    // var id = whatItHit.transform.gameObject.GetPhotonView().ViewID;
                    // PV.RPC("RPC_Delete", RpcTarget.All, id); // tar bort men ger error.
                }

                //PhotonNetwork.Destroy(whatItHit.transform.gameObject); Tar bort för alla, behöver Photonview
                //PV.RPC("RPC_Ray", RpcTarget.All);
            }
        }

        BasicMovement();
        ToggleFlashLight();
    }

    [PunRPC]
    void RPC_Delete(int id)
    {
        // PhotonNetwork.Destroy(PhotonView.Find(id));
        //  PhotonView.Find(id).GetComponent<ButtonScript>().button_Pressed();
        //PhotonView.Find(id).GetComponent<Animation>().Play();
    }

    /* [PunRPC]
     void RPC_Ray()
     {
         var ray = myCamera.ScreenPointToRay(Input.mousePosition);
         if (Physics.Raycast(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward), out var whatItHit, 1000))
         {
             rayGameObject = whatItHit.collider.gameObject;
             //raycastHitId = rayGameObject.GetPhotonView().ViewID;
             PhotonNetwork.Destroy(rayGameObject);
         }
        
         
        
 
         //var selection = hit.transform;
             //var selectionRenderer = selection.GetComponent<Renderer>();
             //if (selectionRenderer != null)
             //{
             //  selectionRenderer.material = highlightMaterial;
             //}
 // Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out whatItHit, distanceToSee);
     }*/

    [PunRPC]
    void RPC_Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.TransformDirection(Vector3.forward),
            out hit, 1000))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void BasicMovement()
    {
        Rigid.MoveRotation(Rigid.rotation *
                           Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X"), 0) *
                                            MouseSensitivity)); //Kroppen snurrar därför gör kameran det också.
        Rigid.MovePosition(transform.position + Input.GetAxis("Vertical") * MoveSpeed * transform.forward +
                           Input.GetAxis("Horizontal") * MoveSpeed * transform.right); //Actual movement
        myCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0f, 0f)); //Kamera upp och ner
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigid.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void ToggleFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLight)
            {
                playerFlashLight.enabled = false;
                flashLight = false;
            }
            else
            {
                playerFlashLight.enabled = true;
                flashLight = true;
            }
        }
    }
}