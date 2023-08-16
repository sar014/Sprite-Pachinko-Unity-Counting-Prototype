using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBall : MonoBehaviour
{
    [Tooltip("Accessing Rigidbody component of spheres")]
    public Rigidbody targetRb;

    [Tooltip("Used for accessing GameOver() func from GameManager script")]
    public GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        obstacles();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(other.CompareTag("Plane"))
        {
            gameManager.GameOver();
        }
    }

    virtual public void obstacles()
    {
        //Adding Force to spheres
        targetRb.AddForce(Vector3.down*Random.Range(12,16),ForceMode.Impulse);

        //Positioning the spheres
        transform.position = new Vector3(Random.Range(-10,10),40f);
    }

}
