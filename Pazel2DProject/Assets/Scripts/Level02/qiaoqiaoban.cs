using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qiaoqiaoban : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
