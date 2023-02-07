using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public World world;
    void Start()
    {
        
    }
    void Update()
    {
        print(transform.position.x);
        if(transform.position.x < 10.5 ){
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 30);
        }
        }
        if(transform.position.x > -10.5){
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 30);
        }}      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            world.Score();
            rigidbody.AddForce(new Vector2(transform.position.x, 100));
        }
    }
}
