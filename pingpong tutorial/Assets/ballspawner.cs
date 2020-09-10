using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballspawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab; //Get the paddle we want to spawn 
    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        GameObject ball = PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity, 0); 
    }
}
