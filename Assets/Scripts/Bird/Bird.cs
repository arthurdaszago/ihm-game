using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    private GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("Plane");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        } 
        
        else if(collision.tag == "Plane")
        {   
            Destroy(plane.gameObject);
        }

        else if(collision.tag == "Rocket")
        {   
            Destroy(this.gameObject);
        }
    }
}
