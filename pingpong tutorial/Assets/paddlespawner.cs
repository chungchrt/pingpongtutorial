using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlespawner : MonoBehaviour
{
    [SerializeField] private GameObject paddlePrefab; //Get the paddle we want to spawn 
    private PhotonView PV;

    private void Start()
    {
            PV = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject paddle = PhotonNetwork.Instantiate(paddlePrefab.name, Gamecontroller.instance.spawnPoint[0].position, Quaternion.identity, 0);
        }
        else
        {
            GameObject paddle = PhotonNetwork.Instantiate(paddlePrefab.name, Gamecontroller.instance.spawnPoint[1].position, Quaternion.identity, 0);
        }

        }
}
