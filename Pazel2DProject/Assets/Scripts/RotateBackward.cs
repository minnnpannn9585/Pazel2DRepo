using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackward : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
    }
}
