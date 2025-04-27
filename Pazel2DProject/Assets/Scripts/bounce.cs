using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour


{
    public float yspeed;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.y > transform.position.y)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(other.gameObject.GetComponent<Rigidbody2D>().velocity.x, yspeed);
        }
    }
}
