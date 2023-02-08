using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject StartScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        //create a boolean called start and set it to true
        bool start = false;
        if (start == false)
        {

            Time.timeScale = 1;
            StartScreen.SetActive(false);
        }
    }
}
