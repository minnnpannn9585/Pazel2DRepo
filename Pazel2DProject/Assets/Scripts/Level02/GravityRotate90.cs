using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRotate90 : MonoBehaviour
{
    public GameObject playerBlack;
    public GameObject playerWhite;
    public bool changeBlack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (changeBlack)
                playerBlack.GetComponent<PlayerBlack>().isLeftRight = !playerBlack.GetComponent<PlayerBlack>().isLeftRight;
            if(!changeBlack)
                playerWhite.GetComponent<PlayerBlack>().isLeftRight = !playerBlack.GetComponent<PlayerBlack>().isLeftRight;
        }
    }
}
