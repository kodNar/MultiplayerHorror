using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;


    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
       // int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length); // den här funkar 
        
        
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"), GameSetup.GS.spawnPoints[GameSetup.spawnCounter].position, GameSetup.GS.spawnPoints[GameSetup.spawnCounter].rotation, 0);
        }
    }

}
