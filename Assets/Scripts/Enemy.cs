using UnityEngine;

public class Enemy : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public BallScript ball;
    float rand;
    float nextInterval;
    float x;
    void Start()
    {
    }
    void Update()
    {
        /* if (Time.time > nextInterval)
        {

            x = ball.CurrentX();
            nextInterval = Time.time + 1f;
        } */
        //if x is less than currentX add force to the right
        if (x < ball.CurrentX())
        {
            x += 0.004f;
        }
        //if x is greater than currentX add force to the left
        if (x > ball.CurrentX())
        {
            x -= 0.004f;
        }



        if (x > 1.9)
        {
            x = 1.9f;
        }
        if (x < -1.9)
        {
            x = -1.9f;
        }
        //random number between 1 and 10
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            rigidbody.AddForce(new Vector2(transform.position.x, -100));
        }
    }

}
