using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : DropBall
{
    override public void obstacles()
    {
        //Adding Force to spheres
        targetRb.AddForce(Vector3.down*Random.Range(12,16),ForceMode.Impulse);

        //Positioning the spheres
        transform.position = new Vector3(Random.Range(-10,10),40f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.CompareTag("Player"))
        {
            gameManager.GameOver();
        }
    }
}

