using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlack : MonoBehaviour
{
    public Rigidbody2D rb;
    public float runSpeed = 2f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float rayDistance = 0.25f;

    public bool isBlack;
    public bool isLeftRight = true;
    public Vector2 gravity;
    public float gravityScale;
    
    void FixedUpdate()
    {
        // 应用自定义重力
        rb.AddForce(gravity * Time.fixedDeltaTime, ForceMode2D.Force);
    }
    
    void Update()
    {
        if (isBlack)
        {
            float h = 0;
            if (Input.GetKey(KeyCode.A)) h = -1;
            if (Input.GetKey(KeyCode.D)) h = +1;
            if (isLeftRight)
            {
                gravity = new Vector2(0f, -gravityScale);
                rb.velocity = new Vector2(h * runSpeed, rb.velocity.y);
            
                if (Input.GetKeyDown(KeyCode.W) && CanJump())
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                gravity = new Vector2(gravityScale, 0f);
                rb.velocity = new Vector2(rb.velocity.x, h*runSpeed);
            
                if(Input.GetKeyDown(KeyCode.W) && CanJump())
                    rb.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            float h = 0;
            if (Input.GetKey(KeyCode.LeftArrow)) h = -1;
            if (Input.GetKey(KeyCode.RightArrow)) h = +1;
            if (isLeftRight)
            {
                gravity = new Vector2(0f, gravityScale);
                rb.velocity = new Vector2(h * runSpeed, rb.velocity.y);
            
                if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
                    rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                gravity = new Vector2(-gravityScale, 0f);
                rb.velocity = new Vector2(rb.velocity.x, h*runSpeed);
            
                if(Input.GetKeyDown(KeyCode.UpArrow) && CanJump())
                    rb.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    
    bool CanJump()
    {
        if (isBlack)
        {
            Vector2 downDir = isLeftRight? Vector2.down : Vector2.right;
            // 从脚底中心往“重力方向的反向”打一条短射线，看有没有碰到地面
            return Physics2D.Raycast(transform.position, downDir, rayDistance, groundLayer);
        }
        else
        {
            Vector2 downDir = isLeftRight? Vector2.up : Vector2.left;
            // 从脚底中心往“重力方向的反向”打一条短射线，看有没有碰到地面
            return Physics2D.Raycast(transform.position, downDir, rayDistance, groundLayer);
        }
    }
}
