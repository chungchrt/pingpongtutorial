using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public static Gamecontroller instance;
    public int leftScore = 0;
    public int rightScore = 0;
    public Text leftScoreText;
    public Text rightScoreText;
    public bool newRound = false;
    public bool gameOver = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored(string paddle)
    {
        if(paddle == "right" && gameOver == false)
        {
            leftScore++;
            leftScoreText.text = "Left Score : " + leftScore.ToString() ;
            newRound = true;
        }
        if (paddle == "left" && gameOver == false )
        {
            rightScore++;
            rightScoreText.text = "Right Score : " + rightScore.ToString();
            newRound = true;
        }
    }
}
