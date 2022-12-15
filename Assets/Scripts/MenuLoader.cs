using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject easyUI;
    public GameObject hardUI;
    public Text easyTxt;
    public Text hardTxt;
    int highScore;

    public void LoadEasy()
    {
        SceneManager.LoadScene("Easy Level");
    }

    public void LoadHard()
    {
        SceneManager.LoadScene("Hard Level");
    }

    public void EasyClicked()
    {   
        // load screen
        menuUI.SetActive(false);
        easyUI.SetActive(true);

        //update highscore
        highScore = PlayerPrefs.GetInt("easyScore");
        easyTxt.text = "Highscore: " + highScore;
    }

    public void HardClicked()
    {
        //load screen
        menuUI.SetActive(false);
        hardUI.SetActive(true);

        //update highscore
        highScore = PlayerPrefs.GetInt("hardScore");
        easyTxt.text = "Highscore: " + highScore;
    }

    public void BackClicked()
    {
        if (easyUI.activeSelf)
        {
            easyUI.SetActive(false);
            menuUI.SetActive(true);
        }
        else if (hardUI.activeSelf)
        {
            hardUI.SetActive(false);
            menuUI.SetActive(true);
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
