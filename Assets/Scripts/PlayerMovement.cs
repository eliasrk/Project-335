using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float gyroDirection;
    public new Rigidbody2D rigidbody;
    //if input.gryo enable &&  input.gyro.attitude,x !=0 angle = input.gyro.attitude.euelerangles.y  if >180 
    void Start()
    {

    }
    /* 
    TODO: StoryBoard, Pictures,Design, Bibliography safe area update, Journals 
    /* 
    * ! add Motion controls for bonus points
    * 
    * if the player presses the left or right arrow key it moves the player
    * if the player touches the left or right side of the screen it moves the player
    * limits how far left and right the player can move
    */
    void Update()
    {
        float touchDirection = 0;
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
            touchDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            touchDirection = -2;
        }
        Input.gyro.enabled = true;



        if (Input.gyro.enabled && Input.gyro.attitude.x != 0)
        {
            float angle = Input.gyro.attitude.eulerAngles.y;
            if (angle > 180)
            {
                angle = (180 - (angle - 180)) * -1;
            }
            gyroDirection = Mathf.Clamp(angle / 15, -1, 1);
        }




        if (transform.position.x < 1.9)
        {

            if (touchDirection > 0 || gyroDirection > 0.5)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 5);
            }
        }
        if (transform.position.x > -1.9)
        {
            if (touchDirection < 0 || gyroDirection < -0.5)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 5);
            }
        }

    }
    public float CurrentX()
    {
        float x = transform.position.x;
        return x;
    }
}
