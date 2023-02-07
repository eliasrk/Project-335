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
        score = PlayerPrefs.GetInt("current");
        highscore = PlayerPrefs.GetInt("highscore");
        live = PlayerPrefs.GetInt("Lives");     
        print ("Lives" + live);
    }

     void Update()
    {
        scoreLabel.text = "Score: " + score;   
        Lives.text = "Lives: " + live;
    }
    public void Score()
    {
        score++;
        if (score > highscore)
        {
            highscore = score;
        }
    }
    public void Save()
    {   
        if(live > 0){
        live--;
        }
        if(score > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        if(PlayerPrefs.GetInt("Lives") == 0)
        {
            
            highScoreLabel.text = "High Score: " + highscore;
            Time.timeScale = 0;
            PlayerDied();
            
            score = 0;
            live = 3;
            print("game over");
            PlayerPrefs.SetInt("Lives", 3);
            PlayerPrefs.SetInt("current", 0);
            
        }else
        {
        PlayerPrefs.SetInt("current", score);
        PlayerPrefs.SetInt("highscore", highscore);
        
        highScoreLabel.text = "High Score: " + highscore;
        PlayerPrefs.SetInt("Lives", live);  
        }
        
        
        
    }
    public void PlayerDied(){
          
          if(score > highscore){
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
          }
          
          highScoreLabel.text = "High Score: " + highscore;

          Time.timeScale = 0;

          gameOverScreen.SetActive(true);
      
    }
    
    public void PlayAgain(){
      Time.timeScale = 1;
      gameOverScreen.SetActive(false);
      SceneManager.LoadScene(0);
    }


}
