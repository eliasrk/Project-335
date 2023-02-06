using UnityEngine;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    float rand;
    private Rigidbody2D rb2d;

    void Start()
    {
        rigidbody.AddForce(new Vector2(0, 1000));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(rand, direction, 0));
    }

}
