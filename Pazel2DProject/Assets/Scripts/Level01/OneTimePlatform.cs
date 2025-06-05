using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimePlatform : MonoBehaviour
{
    public float timer;
    private bool isCounting;
    private void OnCollisionEnter2D(Collision2D other)
    {
        isCounting = true;
        timer = 0;
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isCounting = false;
        timer = 3;
    }
    private void Update()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        if (!isCounting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
