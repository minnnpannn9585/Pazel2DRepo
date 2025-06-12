using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSwitch : MonoBehaviour
{
    public circleRotate circleBlack;
    public Color initialColor;

    private void Start()
    {
        initialColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        circleBlack.rotateSpeed = -circleBlack.rotateSpeed;
       
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        circleBlack.rotateSpeed = -circleBlack.rotateSpeed;
        
        GetComponent<SpriteRenderer>().color = initialColor;
    }
}
