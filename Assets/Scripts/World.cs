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
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI highScoreLabel;
    int score;
    int highscore;
    int round;
    // * gets the high score and the rounds
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        round = PlayerPrefs.GetInt("lives");
        Time.timeScale = 1;
    }
    // * updates the score and the rounds
    void Update()
    {
        scoreLabel.text = "Score: " + PlayerPrefs.GetInt("current");
        Lives.text = "Rounds: " + round;
    }
    // * if the highscore is beat it updates it
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
    /*
    * Saves the high score and the current score
    * If the player no rounds left, the game is reset and the player is taken back to the main scene
    * every time a round is lost, the player is taken back to the main scene
    * if you dont have any lives it resets the counter and the score
    */
    public void Save()
    {
        score = PlayerPrefs.GetInt("current");
        print(score);
        if (round > 0)
        {
            round--;
            SceneManager.LoadScene(1);
        }
        if (score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if (PlayerPrefs.GetInt("lives") == 0)
        {
            highScoreLabel.text = "High Score: " + highscore;
            FinalScore.text = "Score: " + score;
            Time.timeScale = 0;
            PlayerDied();
            score = 0;
            round = 3;
            PlayerPrefs.SetInt("lives", 3);
            PlayerPrefs.SetInt("current", 0);
        }
        else
        {
            PlayerPrefs.SetInt("current", score);
            PlayerPrefs.SetInt("highscore", highscore);
            highScoreLabel.text = "High Score: " + highscore;
            PlayerPrefs.SetInt("lives", round);
        }
    }
    /* 
    * Updates the high score if the current score is higher than the high score
    * and displays the game over screen
    * Pauses the game
    */
    public void PlayerDied()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        highScoreLabel.text = "High Score: " + highscore;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
    /*
    * Resets the game and reloads the scene
    * starts the main scene again
    */
    public void PlayAgain()
    {
        Time.timeScale = 1;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
