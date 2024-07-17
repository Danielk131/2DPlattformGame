using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawEnemy : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float startposition;
    //How far will the saw move
    [SerializeField] private float moveDistance = 3;
    private float endposition;
    private float velocity=15f;
    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startposition = rigidbody2d.transform.position.x;
        endposition = startposition + moveDistance;

    }

    // Update is called once per frame
    void Update()
    {
        //Checks where the enemy will move. 
        //Will move right if it on the way right and not at the endposition
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
        //Will moveleft if at the endposition, and moving left and not yet at the startposition
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
