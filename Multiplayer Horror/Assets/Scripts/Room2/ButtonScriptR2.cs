using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ButtonScriptR2 : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject elevator1;

    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data

        }
        else if (stream.IsReading)
        {
            //Network read this, others see
        }
    }

    public void Button_pressedR2(string hit)
    {
        PV.RPC("Button_Pressed_Network_R2", RpcTarget.All, hit);
    }

    void Button_Pressed_Network_R2()
    {
        
    }
}
