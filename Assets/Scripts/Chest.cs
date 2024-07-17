using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private int totalNumberCoins;
    private int currentScene;

    private void Start()
    {
        animator = GetComponent<Animator>();
        totalNumberCoins = GameObject.FindObjectsOfType(typeof(Coins)).Length;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current scene number : " + currentScene);
        //Debug.Log(totalNumberCoins);
    }
    //If all coins are collected it will open the chest
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            if (GameObject.FindObjectsOfType(typeof(Coins)).Length == 0)
            {
                Debug.Log("Spiller animasjon!");
                animator.SetTrigger("Open Chest");
                StartCoroutine(Wait(2));
            }
        }
    }

    //After waiting for x seconds it will load the next scene
    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        currentScene++;
        SceneManager.LoadScene(currentScene);

    }
}

