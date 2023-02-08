using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;

public class World : MonoBehaviour
{

    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI Lives;

    public GameObject gameOverScreen;

    public TextMeshProUGUI highScoreLabel;
    int score;
    int highscore;
    int live;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        live = PlayerPrefs.GetInt("Lives");
    }

    void Update()
    {
        scoreLabel.text = "Score: " + PlayerPrefs.GetInt("current");
        Lives.text = "Rounds: " + live;
    }
    public void Score()
    {
        score = PlayerPrefs.GetInt("current");
        score++;
        PlayerPrefs.SetInt("current", score);
        if (score > highscore)
        {
            highscore = score;
        }
    }
    public void Save()
    {

        score = PlayerPrefs.GetInt("current");
        print(score);
        if (live > 0)
        {
            live--;
            SceneManager.LoadScene(0);
        }
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if (PlayerPrefs.GetInt("Lives") == 0)
        {

            highScoreLabel.text = "High Score: " + highscore;
            Time.timeScale = 0;
            PlayerDied();

            score = 0;
            live = 3;
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("current", 0);

        }
        else
        {
            PlayerPrefs.SetInt("current", score);
            PlayerPrefs.SetInt("highscore", highscore);

            highScoreLabel.text = "High Score: " + highscore;
            PlayerPrefs.SetInt("Lives", live);
        }



    }
    public void PlayerDied()
    {

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }

        highScoreLabel.text = "High Score: " + highscore;

        gameOverScreen.SetActive(true);
        Time.timeScale = 0;


    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }


}
