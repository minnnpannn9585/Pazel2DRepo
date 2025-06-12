using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointLevel1 : MonoBehaviour
{
    PassLevel1 pass1;
    private void Start()
    {
        pass1 = transform.parent.GetComponent<PassLevel1>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pass1.score++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pass1.score--;
        }
    }
}
