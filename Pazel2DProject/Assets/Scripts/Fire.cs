using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float num;

    void Update()
    {
        num = transform.parent.GetComponent<Rigidbody2D>().gravityScale;
        transform.rotation = Quaternion.Euler(0, 0, 90 - num * 90);
    }
}
