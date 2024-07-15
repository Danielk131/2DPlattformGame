using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEnemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float startposition;
    private float endposition;
    private float velocity=15f;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startposition = rigidbody2d.transform.position.x;
        endposition = startposition + 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight) {
            if (rigidbody2d.transform.position.x < endposition)
            {
                rigidbody2d.AddForce(new Vector2(velocity, 0) * Time.deltaTime);
            }
            else
            {
                moveRight = false;
                velocity *= -1;
                rigidbody2d.velocity = new Vector2(0, 0);

            }
        }
        else
        {
            if (rigidbody2d.transform.position.x > startposition)
            {
                rigidbody2d.AddForce(new Vector2(velocity, 0) * Time.deltaTime);
            }
            else
            {
                moveRight = true;
                velocity *= -1;
                rigidbody2d.velocity = new Vector2(0, 0);

            }
        }
        
    }
}
