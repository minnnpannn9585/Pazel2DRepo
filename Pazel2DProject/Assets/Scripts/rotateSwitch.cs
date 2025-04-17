using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSwitch : MonoBehaviour
{
    //public circleRotate circleWhite;
    public circleRotate circleBlack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       //circleWhite.rotateSpeed = -circleWhite.rotateSpeed;
       circleBlack.rotateSpeed = -circleBlack.rotateSpeed;
    }
}
