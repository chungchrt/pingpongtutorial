using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonstart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  StartTheGame()
    {
        Gamecontroller.instance.startGame = true;
    }
}
