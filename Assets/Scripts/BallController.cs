using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D rb;

    private Vector2 startingVelocity = new Vector2(5f, 5f);

    public float speedUp = 1.1f;

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("WallPlayerTwo"))
        {
            gameManager.ScorePlayerTwo();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayerOne"))
        {
            gameManager.ScorePlayerOne();
            ResetBall();
        }

    }

}
