using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MaceEnemy : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private float delay;
    private float velocity;
    private float startPosition;
    private bool moveUp = false;
    private float startGravity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        delay = 1f;
        velocity = 18f;
        startPosition = rigidbody2D.transform.position.y;
        startGravity = rigidbody2D.gravityScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp) {

            if (rigidbody2D.transform.position.y < startPosition)
            {
                rigidbody2D.AddForce(new Vector2(0, velocity) * Time.deltaTime);
            }
            else
            {
                //Debug.Log("Detter ned");
                moveUp = false;
                rigidbody2D.gravityScale = startGravity;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Tilemap"))
        {
            //Debug.Log("Kollisjon!");
            rigidbody2D.gravityScale = 0;
            Debug.Log(rigidbody2D.gravityScale);
            moveUp = true;
            //Debug.Log(rigidbody2D.transform.position.y);
            //Debug.Log("Start pos y : " + startPosition);
        }
    }

}
