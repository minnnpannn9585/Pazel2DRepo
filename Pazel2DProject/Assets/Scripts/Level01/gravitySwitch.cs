using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitySwitch : MonoBehaviour
{
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb1.gravityScale = -rb1.gravityScale;
        rb2.gravityScale = -rb2.gravityScale;
    }
}
