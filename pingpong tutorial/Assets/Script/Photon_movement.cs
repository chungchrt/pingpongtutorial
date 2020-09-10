using Photon.Pun;
using System;
using UnityEngine;

public class Photon_movement : MonoBehaviourPun
{

    // Start is called before the first frame update
    [SerializeField]private float _speed = 50; //speed of the paddle
    private float length;
    private PhotonView PV;
    private Rigidbody2D rb;
    void Start()
    {
        length = GetComponent<BoxCollider2D>().size.y; // get length through boxcollider
        PV = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        if (rb.position.y > (Gamecontroller.instance.borderTall/2 - length / 2)) // if paddle reaches border => low speed to prevent break through collision
        {
            rb.velocity = new Vector2(0, 0);
            _speed = 0;
        }
        if (rb.position.y < (-Gamecontroller.instance.borderTall / 2 + length / 2))// if paddle reaches bot border => low speed to prevent break through collision
        {
            rb.velocity = new Vector2(0, 0);
            _speed = 0;
        }
        if (Input.GetKey("down"))
        {
            if (_speed == 0 && rb.position.y > (Gamecontroller.instance.borderTall / 2 - length / 2)){
                _speed = 50;
            }
              _speed *= 1 + Time.deltaTime;
            rb.velocity = new Vector2(0,-1) * _speed;
           // rb.velocity = (Vector2.down*_speed);
        }

        if (Input.GetKey("up"))
        {
            if (_speed == 0 && rb.position.y < (-Gamecontroller.instance.borderTall / 2 + length / 2)){
                _speed = 50;
            }
            _speed *= 1 + Time.deltaTime;
            rb.velocity = new Vector2(0, 1 )* _speed;
            //rb.velocity =  (Vector2.down * _speed);
        }
        if (Input.GetKeyUp("up")) // when you let go , iits return 50
        {
            _speed = 50;
        }
        if (Input.GetKeyUp("down"))// when you let go , iits return 50
        {
            _speed = 50;
        }
    }
}
