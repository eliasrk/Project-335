using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public new Rigidbody2D rigidbody;

    void Start()
    {

    }
    /* 
    ! add Motion controls for bonus points
    * 
    * if the player presses the left or right arrow key it moves the player
    * if the player touches the left or right side of the screen it moves the player
    * limits how far left and right the player can move
    */
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
}
