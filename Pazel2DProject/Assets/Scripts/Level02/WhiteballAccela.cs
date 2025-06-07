using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteballAccela : MonoBehaviour
{
    public Rigidbody2D player2Rb;
    bool push = false;
    public float maxLeftVelocity = -4;
    public float maxRightVelocity = 0;
    public float pushForce = -2;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player2>().maxLeftVelocity = maxLeftVelocity;
            other.GetComponent<Player2>().maxRightVelocity = maxRightVelocity;
            push = true;
        }
    }

    private void Update()
    {
        if (push)
            player2Rb.AddForce(new Vector2(pushForce, 0), ForceMode2D.Force);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player2>().maxLeftVelocity = -2f;
            other.GetComponent<Player2>().maxRightVelocity = 2f;
            push = false;
        }
    }
}
