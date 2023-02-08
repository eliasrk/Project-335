using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    public World world;
    float rand;
    private Rigidbody2D rb2d;

    // * gives the ball a intial force 
    void Start()
    {
        rand = Random.Range(-7f, 7f);
        rigidbody.AddForce(new Vector2(0, 10));
        rigidbody.AddForce(new Vector2(10 * rand, 0));
    }

    /* 
    *   limits the speed of the ball
    *   if th ball goes off the screen it resets the game
    */
    void Update()
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

        if (transform.position.x > 3 || transform.position.x < -3 || transform.position.y > 6 || transform.position.y < -6)
        {

            SceneManager.LoadScene(0);
        }

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
            world.Score();
            rigidbody.AddForce(new Vector2(transform.position.x, 100));
        }

    }


}
