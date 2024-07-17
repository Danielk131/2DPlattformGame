using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coins : MonoBehaviour
{

    //When coins collide with the player, it should add a coin to the score and delete itself
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreScript.instance.AddCoinPoint();

            Destroy(gameObject);
        }   
    }
}
