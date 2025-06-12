using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    public Vector3 player01Pos;
    public Vector3 player02Pos;
    private Transform player01;
    private Transform player02;

    private void Start()
    {
        player01Pos = GameObject.Find("GameManagerLevel2").GetComponent<GameManagerLv2>().player01Pos;
        player02Pos = GameObject.Find("GameManagerLevel2").GetComponent<GameManagerLv2>().player02Pos;
        player01 = GameObject.Find("Player1").transform;
        player02 = GameObject.Find("Player2").transform;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player01.position = player01Pos;
            player01.GetComponent<PlayerBlack>().isLeftRight = true;
            player02.position = player02Pos;
            player02.GetComponent<PlayerBlack>().isLeftRight = true;
            // if (other.gameObject.name == "Player1")
            // {
            //     other.transform.position = player01Pos;
            //     other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            // }
            // else if (other.gameObject.name == "Player2")
            // {
            //     other.transform.position = player02Pos;
            //     other.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
            // }
        }
    }
}
