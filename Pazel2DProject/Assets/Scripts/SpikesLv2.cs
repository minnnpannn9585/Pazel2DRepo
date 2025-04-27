using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesLv2 : MonoBehaviour
{
    public Vector3 player01Pos;
    public Vector3 player02Pos;

    private void Start()
    {
        player01Pos = GameObject.Find("GameManagerLevel2").GetComponent<GameManagerLv2>().player01Pos;
        player02Pos = GameObject.Find("GameManagerLevel2").GetComponent<GameManagerLv2>().player02Pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.name == "Player1")
            {
                other.transform.position = player01Pos;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else if (other.gameObject.name == "Player2")
            {
                other.transform.position = player02Pos;
                other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }
    }
}
