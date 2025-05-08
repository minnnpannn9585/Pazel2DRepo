using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathzoneLv1 : MonoBehaviour
{
    public Vector3 player01Pos;
    public Vector3 player02Pos;
    private Transform player01;
    private Transform player02;

    private void Start()
    {
        player01 = GameObject.Find("Player1").transform;
        player02 = GameObject.Find("Player2").transform;
        player01Pos = player01.position;
        player02Pos = player02.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            //if (other.gameObject.name == "Player1")
            {
                player01.position = player01Pos;
                player01.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            //else if (other.gameObject.name == "Player2")
            {
                player02.position = player02Pos;
                player02.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }
    }
}
