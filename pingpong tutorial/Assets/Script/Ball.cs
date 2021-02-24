using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditor;
using UnityEngine;


/* How to make the ball not shaky 101
 * 1: use Velocity instead of transfrom.translate (Use physics) , as transfrom.translate is == teleport
 * 2:  use Photon Rigidbody2d transfrom View + TransformView Classic ( set estimate speed) Together;
 * 3:!!!!!need to check about interoplate  / setting interpolate is smoother
 * 
 * Trigeer in out for accurate score */

/// <summary>
/// RPC is called twice now , fix it !
/// the score is not synced rn , have a chance to bug out;
/// </summary>
public class Ball : MonoBehaviour
{
    public PhotonView PV;
    private Rigidbody2D myRb;
    public float speed = 50;
    private float xSpeed = 0f;
    private float ySpeed = 0f;
    private float length;
    private bool setSpeed = false;
    private bool newRound = false;

    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (newRound == true)
        {
            PV.RPC("StopTimeAndRestartGame", RpcTarget.All);
        }
        if (Gamecontroller.instance.gameOver == false && !setSpeed) // Need change 
        {
            setSpeed = true;
            xSpeed = 1f;
            ySpeed = 1f;
        }
        if (newRound == false) { 
            MoveBall();
            Debug.Log("Gamecontroller.instance.newRound in else if :false" + newRound);
            Debug.Log("Gamecontroller.instance.newRound in else if :false" + newRound);
        }
        
    }
    [PunRPC]
    void StopTimeAndRestartGame()
    {
        StartCoroutine(RestartGame(newRound));//when it get called , pass the current newRound and sync it .
    }
    IEnumerator RestartGame(bool syncin) //sync the newRound then wait 3 second
    {
        newRound = syncin;
        if (newRound == true){ 
        myRb.position= new Vector2(0, 0);
        myRb.velocity = new Vector2(0, 0);
        setSpeed = false;
        speed = 50;    
        yield return new WaitForSeconds(3f);
        newRound = false;
        }
    }
    private void MoveBall()
    {
        myRb.velocity = new Vector2(xSpeed*speed, ySpeed*speed);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bot")
        {
            ySpeed *= -1;
            speed += 5;
            Debug.Log("Ontrigger enter bot");
        }
        if (other.gameObject.tag == "top")
        {
            ySpeed *= -1;
            speed += 5;
        }
        if (other.gameObject.tag == "paddle")
        {
            xSpeed *= -1;
            speed += 5;
        }
        if (other.gameObject.CompareTag("left"))
        {
            Debug.Log("Ontrigger enter left");
            newRound = true;
            Gamecontroller.instance.Scored("left");
        }
        if (other.gameObject.CompareTag("right"))
        {
            Debug.Log("Ontrigger enter right");
            newRound = true;
            Gamecontroller.instance.Scored("right");
        }
    }


   private void OnTriggerExit2D (Collider2D other)
    {
        PV.RPC("RPC_SendNewRound", RpcTarget.All, newRound);//Sync the newRound variable and side
    }
  
   [PunRPC]
    void RPC_SendNewRound(bool syncIn ) //RPC to synce the newRound and call Scored(side)
    {
        newRound = syncIn;
        
    }
}
