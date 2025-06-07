using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public bool facingUp;
    public bool facingDown;
    public bool facingLeft;
    public bool facingRight;
    public float speed;
    public float force;

    public bool upleft;
    public bool upright;
    public bool downleft;
    public bool downright;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        if (upleft)
        {
            rb.AddForce(new Vector2(-force, force), ForceMode2D.Impulse);
        }
        if (upright)
        {
            rb.AddForce(new Vector2(force, force), ForceMode2D.Impulse);
        }
        if (downleft)
        {
            rb.AddForce(new Vector2(-force, -force), ForceMode2D.Impulse);
        }
        if (downright)
        {
            rb.AddForce(new Vector2(force, -force), ForceMode2D.Impulse);
        }

        if (facingUp)
        {
            if (other.transform.position.y > transform.position.y)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, speed);
            }
        }
        if (facingDown)
        {
            if (other.transform.position.y < transform.position.y)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, -speed);
            }
        }
        if (facingLeft)
        {
            if (other.transform.position.x < transform.position.x)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (facingRight)
        {
            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
