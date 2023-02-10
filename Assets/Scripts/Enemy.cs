using UnityEngine;
public class Enemy : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public BallScript ball;
    float rand;
    float nextInterval;
    float x;
    void Update()
    {
        /* 
        *   it makes the enemy slowly track the ball 
        *   originally had it track the ball constantly but it was too hard and you couldnt win 
        *   making it update every second made it too slow
        *   also limits how far left and right the enemy can move 
        */
        if (x < ball.CurrentX())
        {
            x += 0.05f;
        }
        //if x is greater than currentX add force to the left
        if (x > ball.CurrentX())
        {
            x -= 0.05f;
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
    // * if the enemy collides with the ball it gives the ball a force
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            rigidbody.AddForce(new Vector2(transform.position.x, -100));
        }
    }

}
