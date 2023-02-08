using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    public World world;
    float rand;
    private Rigidbody2D rb2d;

    void Start()
    {
        rand = Random.Range(-7f, 7f);
        rigidbody.AddForce(new Vector2(0, 10));
        rigidbody.AddForce(new Vector2(10 * rand, 0));
    }

    // Update is called once per frame
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

    public float CurrentX()
    {
        float x = transform.position.x;
        return x;
    }
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
