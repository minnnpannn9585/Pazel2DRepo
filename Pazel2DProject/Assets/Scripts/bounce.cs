using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    public bool facingUp;
    public bool facingDown;
    public bool facingLeft;
    public bool facingRight;
    public float yspeed;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (facingUp)
        {
            if (other.transform.position.y > transform.position.y)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, yspeed);
            }
        }
        if (facingDown)
        {
            if (other.transform.position.y < transform.position.y)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, -yspeed);
            }
        }
        if (facingLeft)
        {
            if (other.transform.position.x < transform.position.x)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-yspeed, other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        if (facingRight)
        {
            if (other.transform.position.x > transform.position.x)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(yspeed, other.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
