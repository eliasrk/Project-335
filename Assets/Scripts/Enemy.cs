using System.Runtime.Serialization;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
        float x = ball.CurrentX();
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            rigidbody.AddForce(new Vector2(0, -100));
        }
    }
}
