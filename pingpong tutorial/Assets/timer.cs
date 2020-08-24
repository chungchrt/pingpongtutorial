using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    TimeSpan ts;
    private Text timertext;
    private float time = 360;
    // Start is called before the first frame update
    void Start()
    {
        timertext = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 1)
        {
            time -= Time.deltaTime;
            ts = TimeSpan.FromSeconds(time);
            timertext.text = string.Format("{0:00} : {1:00}", ts.Minutes, ts.Seconds);
            
        }
        if (time <= 1)
        {
            Gamecontroller.instance.gameOver = true;
        }
    }
}
