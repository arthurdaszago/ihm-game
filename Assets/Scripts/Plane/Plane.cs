using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float planeSpeed;

    private Rigidbody2D rb;
    private Vector2 planeDirection;

    public float rateRotation = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        planeDirection = new Vector2(0, directionY).normalized;

        float planeY = rb.position.y;


        if (directionY == 1)
        {
            if (rb.rotation < 25 && planeY <= 2.75f)
            {
                rb.rotation += rateRotation;
            }
            else
            {
                if (rb.rotation > 0)
                {
                    rb.rotation -= rateRotation;
                }
                else 
                {
                    rb.rotation += rateRotation;
                }
            }
        }
        else if (directionY == -1)
        {
            if (rb.rotation > -25 && planeY >= -2.75f)
            {
                rb.rotation -= rateRotation;
            }
            else
            {
                if (rb.rotation > 0)
                {
                    rb.rotation -= rateRotation;
                }
                else 
                {
                    rb.rotation += rateRotation;
                }
            }
        }

        else 
        {
            if (rb.rotation > 0)
            {
                rb.rotation -= rateRotation;
            }
            else 
            {
                rb.rotation += rateRotation;
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, planeDirection.y * planeSpeed);
    }
}
