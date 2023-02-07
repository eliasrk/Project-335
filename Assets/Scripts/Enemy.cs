

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public BallScript ball;
    void Start()
    {
    }
    void Update()
    {
        //limit x to between -10.5 and 10.5

        float x = ball.CurrentX();
        if (x > 10.5)
        {
            x = 10.5f;
        }
        if (x < -10.5)
        {
            x = -10.5f;
        }
        
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
