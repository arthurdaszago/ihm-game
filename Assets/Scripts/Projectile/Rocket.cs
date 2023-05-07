using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject projectile;
    private GameObject rocket;

    private float myTime = 0.0f;
    public float fireDelta = 0.5f;
    private float nextFire = 1f;

    private float rocketSpeed = 22f;

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {

            nextFire = myTime + fireDelta;
            Spawn();

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

    void Spawn()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - 1.55f, 0);
        rocket = Instantiate(projectile, newPosition, transform.rotation);
    }

    void FixedUpdate()
    {
        if (rocket != null)
        {
            rocket.transform.position = rocket.transform.position + new Vector3(rocketSpeed * Time.deltaTime, 0.10f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Bird")
        {
            Destroy(this.gameObject);
            Destroy(rocket.GetComponent<Rigidbody2D>());
            Destroy(rocket.GetComponent<BoxCollider2D>());
        }
    }
}
