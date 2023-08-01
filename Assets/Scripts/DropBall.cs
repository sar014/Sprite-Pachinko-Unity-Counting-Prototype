using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBall : MonoBehaviour
{
    [Tooltip("Accessing Rigidbody component of spheres")]
    private Rigidbody targetRb;

    [Tooltip("Used for accessing GameOver() func from GameManager script")]
    private GameManager gameManager;

    private BoxCollider planeCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        planeCollider = GameObject.Find("Plane").GetComponent<BoxCollider>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.down*Random.Range(12,16),ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-10,10),40f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.CompareTag("Plane"))
        {
            gameManager.GameOver();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
