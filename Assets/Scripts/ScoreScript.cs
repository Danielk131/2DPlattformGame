using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    [SerializeField] private Text scoreText;

    int coins = 0;

    private void Awake()
    {
        scoreText.text = coins.ToString();
        instance = this;
        Debug.Log("Instans");
    }
    public void AddCoinPoint()
    {
        Debug.Log("Inne i add coin");
        coins += 1;
        scoreText.text = coins.ToString();
    }
}
