using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    void Start()
    {

    }
    void Update()
    {
        int touchDirection = 0;
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                touchDirection = -1;
            }
            else
            {
                touchDirection = 1;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            touchDirection = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            touchDirection = -1;
        }
        if (transform.position.x < 1.9)
        {
            if (touchDirection == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 10);
            }
        }
        if (transform.position.x > -1.9)
        {
            if (touchDirection == -1)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 10);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            rigidbody.AddForce(new Vector2(transform.position.x, transform.position.y));
        }
    }
}
