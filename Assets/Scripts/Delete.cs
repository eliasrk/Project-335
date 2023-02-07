using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Delete : MonoBehaviour
{
    public World world;
    public int current;
    void Start()
    {
    }
    void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            
            world.Save();
        SceneManager.LoadScene(0);

        }
    }
}
