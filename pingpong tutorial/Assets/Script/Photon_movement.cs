using Photon.Pun;
using System;
using UnityEngine;

public class Photon_movement : MonoBehaviourPun
{

    // Start is called before the first frame update
    [SerializeField]private float speed = 50; //speed of the paddle
    private float length;
    void Start()
    {
        length = GetComponent<BoxCollider2D>().size.y; // get length through boxcollider
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
        if (transform.position.y > (40 - length / 2)) // if paddle reaches border => low speed to prevent break through collision
        {
            speed = 30;
        }
        if (transform.position.y < (-40 + length / 2))// if paddle reaches border => low speed to prevent break through collision
        {
            speed = 30;
        }
        if (Input.GetKey("down"))
        {
            speed *= 1 + Time.deltaTime;
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }

        if (Input.GetKey("up"))
        {
            speed *= 1 + Time.deltaTime;
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (Input.GetKeyUp("up"))
        {
            speed = 50;
        }
        if (Input.GetKeyUp("down"))
        {
            speed = 50;
        }
    }
}
