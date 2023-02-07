using UnityEngine;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    float rand;
    private Rigidbody2D rb2d;

    void Start()
    {
        rand = Random.Range(-7f, 7f);
        rigidbody.AddForce(new Vector2(0, 100));
        rigidbody.AddForce(new Vector2(100* rand, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //check if its going up or down faster than 10
        if (rigidbody.velocity.y < 10 )
        {
           //if its going up
            if (rigidbody.velocity.y > 0)
            {
                //add force to make it go up faster
                rigidbody.AddForce(new Vector2(transform.position.x, 10));
            }
        }
        if(rigidbody.velocity.y > -10){
            if(rigidbody.velocity.y < 0){
                rigidbody.AddForce(new Vector2(transform.position.x, -10));
            }
        }

    }

    public float CurrentX()
    {
        float x = transform.position.x;
        return x;
    }


}
