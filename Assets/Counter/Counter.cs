using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    GameManager gameManager;
    public Text CounterText;

    private int Count = 0;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameManager.isGameActive)
        {
            Count += 1;
            CounterText.text = "Count : " + Count;
        }
        
    }
}
