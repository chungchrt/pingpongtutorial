using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller instance = null;
    public bool startGame = false;

  public Transform[] spawnPoint; //get the both spawnpoint

    //Nonserialized Variable//
    public Text getPingText;
    public int leftScore = 0;
    public int rightScore = 0;
    public Text leftScoreText;
    public Text rightScoreText;
    public bool gameOver = false;
    public GameObject borderTop;
    public GameObject borderLeft;
    public float borderLength;
    public float borderTall;
    //Nonserialized Variable//

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this) //singleton
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        borderLength = borderTop.GetComponent<BoxCollider2D>().size.y;
        borderTall = borderLeft.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        getPingText.text = "The Ping is " + PhotonNetwork.GetPing().ToString();
    }

    public void Scored(string paddle)
    {
        if(paddle == "right" && gameOver == false)
        {
            leftScore++;
            leftScoreText.text = "Left Score : " + leftScore.ToString() ;
        }
        if (paddle == "left" && gameOver == false )
        {
            rightScore++;
            rightScoreText.text = "Right Score : " + rightScore.ToString();
        }
    }
}
