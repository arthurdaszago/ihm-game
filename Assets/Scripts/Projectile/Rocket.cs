using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float fireDelta = 0.5f;
    public GameObject projectile;

    private float nextFire = 0.5f;
    private float myTime = 0.0f;
    private Rigidbody2D rb;

    private GameObject plane;

    void Start()
    {
        
        rb.GetComponent<Rigidbody2D>();
        plane = GameObject.FindGameObjectWithTag("Plane");
    }

    // Update is called once per frame
    void Update()
    {

        float rocketY = plane.transform.position.y - 100;
        float rocketX = plane.transform.position.x;

        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            Instantiate(projectile, plane.transform.position, plane.transform.rotation) as GameObject;

            // create code here that animates the newProjectile

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }

        if (projectile != null)
        {
            rb.velocity = new Vector2(plane.transform.position.y * 10, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        } 
        
        else if(collision.tag == "Bird")
        {   
            Destroy(this.gameObject);
        }
    }
}
