using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    public World world;
    float rand;
    float tempTime;
    private Rigidbody2D rb2d;

    // * gives the ball a intial force 
    void Start()
    {
        rand = UnityEngine.Random.Range(-10f, 10f);
        rigidbody.AddForce(new Vector2(25 * rand, -10));
        tempTime = Time.time + 2f;
    }

    /* 
    *   limits the speed of the ball
    *   if th ball goes off the screen it resets the game
    */
    void Update()
    {
        // * fixes the bug where the ball would get stuck at the side and you could get infinite points
        if (Time.time > tempTime)
        {
            print("add force");

            //if the is between 1.6 and 2.11 for more than 2 seconds it gets a force to the left
            if (transform.position.x > 1.6 && transform.position.x < 2.11)
            {
                rigidbody.AddForce(new Vector2(-100, 0));
            }
            //if the is between -1.6 and -2.11 for more than 2 seconds it gets a force to the right
            if (transform.position.x < -1.6 && transform.position.x > -2.11)
            {
                rigidbody.AddForce(new Vector2(100, 0));
            }
            tempTime = Time.time + 2f;
        }
        constrainst();

    }

    // *    Gets current x position of ball for the enemy to use to track it 
    public float CurrentX()
    {
        float x = transform.position.x;
        return x;
    }
    // * if it collides with the player it gets a force
    // * if it collides with the delete it saves the score and resets the game
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Delete")
        {
            world.Save();
        }
        if (collision.gameObject.tag == "Player")
        {

            Handheld.Vibrate();
            world.Score();
            // *    add a bit more side force to the ball
            int rand = 100;
            if (transform.position.x > 0)
            {
                rand = Math.Abs(rand);
            }
            else
            {
                rand = -Math.Abs(rand);
            }
            rigidbody.AddForce(new Vector2(transform.position.x + rand, 100));
        }

    }
    private void constrainst()
    {

        //check if its going up or down faster than 10
        if (rigidbody.velocity.y < 10)
        {
            //if its going up
            if (rigidbody.velocity.y > 0)
            {
                //add force to make it go up faster
                rigidbody.AddForce(new Vector2(transform.position.x, 10));
            }
        }
        if (rigidbody.velocity.y > -10)
        {
            if (rigidbody.velocity.y < 0)
            {
                rigidbody.AddForce(new Vector2(transform.position.x, -10));
            }
        }
        // * attempt at limiting the speed horizontally 
        if (rigidbody.velocity.x > 10)
        {
            rigidbody.velocity = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (rigidbody.velocity.x < -10)
        {
            rigidbody.velocity = new Vector3(10, transform.position.y, transform.position.z);
        }
        //* if the ball leaves the area it refreshes the scene
        if (transform.position.x > 3 || transform.position.x < -3 || transform.position.y > 6 || transform.position.y < -6)
        {
            SceneManager.LoadScene(0);
        }
    }


}
