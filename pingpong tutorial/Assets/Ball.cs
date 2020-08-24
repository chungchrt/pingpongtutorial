using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 70;
    private bool topcol = false;

    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(1f,-1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamecontroller.instance.gameOver == false) { 
        transform.Translate(direction*Time.deltaTime*speed);
        if (Gamecontroller.instance.newRound == true)
        {
            transform.position = new Vector2(0, 0);
            speed = 70;
            Gamecontroller.instance.newRound = false;
        }
    }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bot" && topcol == false)
        {
            direction.y  *= -1;
            topcol = true;
            speed += 5;
        }
        if (other.gameObject.tag == "top")
        {
            direction.y *= -1;
            speed += 5;
        }
        if (other.gameObject.tag == "paddle")
        {
            direction.x *= -1;
            speed += 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("left"))
        {
            Gamecontroller.instance.Scored("left");
        }
        if (other.gameObject.CompareTag("right"))
        {
            Gamecontroller.instance.Scored("right");
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "bot" && topcol==true)
        {
            topcol = false;
        }
    }
}
