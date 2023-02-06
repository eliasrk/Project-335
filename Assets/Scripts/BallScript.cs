using UnityEngine;

public class BallScript : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    float direction;
    float rand;
    private Rigidbody2D rb2d;

    void Start()
    {
        rand = Random.Range(-0.3f, 0.3f);
        rigidbody.AddForce(new Vector2(0, 1000));
    }

    // Update is called once per frame
    void Update()
    {
    }

}
