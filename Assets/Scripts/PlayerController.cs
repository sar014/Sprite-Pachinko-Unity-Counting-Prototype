using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("For Controlling the player")]
    private float horizontalInput;

    [Tooltip("Speed")]
    private float speed = 20.0f;

    [Tooltip("Range for left and right boundary")]
    private float xRange = 25;

    // Update is called once per frame
    void Update()
    {
        //Check for right bounds:
        if(transform.position.x<-xRange)
        {
            transform.position = new Vector3(-xRange,transform.position.y,transform.position.z);
        }

        //Check for left bounds:
        if(transform.position.x>xRange)
        {
            transform.position = new Vector3(xRange,transform.position.y,transform.position.z);
        }

        //Moving the player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
    }
}
