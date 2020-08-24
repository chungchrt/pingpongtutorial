using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed =50; //speed of the paddle
    private float length; // length of the paddele
    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<BoxCollider2D>().size.y; // get length through boxcollider
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > (40 - length / 2)) // if paddle reaches border => low speed to prevent break through collision
       {
           speed =30;
        }
        if (transform.position.y < (-40 + length / 2))// if paddle reaches border => low speed to prevent break through collision
        {
           speed = 30;
       }
        if (Input.GetKey("down"))
        {
            speed *= 1 + Time.deltaTime;
            transform.Translate(Vector2.down*Time.deltaTime*speed);
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if( ( other.gameObject.CompareTag("top")) || (other.gameObject.CompareTag("bot")))
        {
            speed = 30;
            Debug.Log("hit border");
        }
    }
}
