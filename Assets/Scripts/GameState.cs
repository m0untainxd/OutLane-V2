using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public static GameState instance = null;
    private int score;
    private int coinsCollected;
    public GameObject[] coins;
    public Text scoreTxt;
    public Text coinsTxt;
    public Text sandTxt;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        Time.timeScale = 1;
    }

    public void coinCollected()
    {
        coinsCollected++;
        score = score + 100;
        scoreTxt.text = score.ToString();
        coinsTxt.text = coinsCollected.ToString();
    }

    public void lap()
    {
        score = score + 1000;
        scoreTxt.text = score.ToString();

        Follower.instance.increaseSpeed();

        // reload all coins
        foreach (GameObject coin in coins)
        {
            coin.GetComponent<Renderer>().enabled = true;
        }
    }

    public void hitSand()
    {   
        if (coinsCollected < 10)
        {
            sandTxt.text = "Uh oh! You hit the sand but lost " + coinsCollected + "coins...";
            coinsCollected = 0;
        }
        else if (coinsCollected == 0)
        {
            sandTxt.text = "Good news, you hit the sand and lost no coins...";
        }
        else
        {
            score = score - 1000;
            coinsCollected = coinsCollected - 10;
            scoreTxt.text = score.ToString();
            coinsTxt.text = coinsCollected.ToString();
            sandTxt.text = "Uh oh! You hit the sand and lost 10 coins";
        }
    }

    public void gameOver()
    {
        PauseGameOver.GameIsOver = true;
    }

    public int getScore()
    {
        return score;
    }

    public int getCoins()
    {
        return coinsCollected;
    }
}
