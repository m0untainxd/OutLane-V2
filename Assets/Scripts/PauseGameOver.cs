using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;
    public Text scoreTxt;
    public Text coinsTxt;
    public Text highScoreTxt;
    int score;
    int coins;
    int highScore;
    Scene scene;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (GameIsOver)
        {
            GameOver();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {   
        gameOverMenuUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0;

        // get final score and coins
        score = GameState.instance.getScore();
        coins = GameState.instance.getCoins();

        // check against playerprefs for scene
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Easy Level")
        {
            highScore = PlayerPrefs.GetInt("easyScore");
            if (highScore < score)
            {
                PlayerPrefs.SetInt("easyScore", score);
                highScoreTxt.text = "New high score!";
            }
        } else if (scene.name == "Hard Level")
        {
            highScore = PlayerPrefs.GetInt("hardScore");
            if (highScore < score)
            {
                PlayerPrefs.SetInt("hardScore", score);
                highScoreTxt.text = "New high score!";
            }
        }

        // update UI
        scoreTxt.text = "Score: " + score;
        coinsTxt.text = "Coins: " + coins; 
    }
}
