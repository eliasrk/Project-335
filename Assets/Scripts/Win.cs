using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Win : MonoBehaviour
{
    // * if the ball collides with the win object it adds 50 points to the score    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            int current = PlayerPrefs.GetInt("current");
            current += 50;
            PlayerPrefs.SetInt("current", current);
        }
    }
}

