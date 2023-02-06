using UnityEngine;

public class BallScript : MonoBehaviour
{
    float direction;
    float rand;
    private Rigidbody2D rb2d;

    void Start()
    {
        rand = Random.Range(-0.2f, 0.2f);
        direction = -1 * Time.deltaTime * 2;
        Invoke("GoBall", 2);
    }
    void GoBall()
    {
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(rand);
        transform.Translate(new Vector3(rand, direction, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("collision" + direction);
            direction = System.Math.Abs(direction);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            print("collision" + direction);
            direction = -1 * direction;
        }
        if (collision.gameObject.tag == "Delete")
        {
            //destroy self
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bounceable")
        {

            if (rand < 0)
            {
                rand = System.Math.Abs(rand);
            }
            else
            {
                rand = -rand;
            }


        }
    }
}
