using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private int totalNumberCoins;

    private void Start()
    {
        animator = GetComponent<Animator>();
        totalNumberCoins = GameObject.FindObjectsOfType(typeof(Coins)).Length;
        Debug.Log(totalNumberCoins);
    }
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

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);

    }
}

