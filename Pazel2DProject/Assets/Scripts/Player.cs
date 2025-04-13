using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isGrounded = true;
    public Transform white;
    public Transform black;
    bool isUp = true;

    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * 0.01f, 0, 0);

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (isGrounded)
            {

                InvertGravity();
                isUp = !isUp;
            }
        }
    }

    void InvertGravity()
    {
        if (isUp)
        {
            for (int i = 0; i < white.childCount; i++)
            {
                white.GetChild(i).GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
        else
        {
            for(int i = 0; i < white.childCount; i++)
            {
                white.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
