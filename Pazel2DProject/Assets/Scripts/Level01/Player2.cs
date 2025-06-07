using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float runSpeed = 2f;
    public float jumpForce = 4f;
    public LayerMask groundLayer;
    public float rayDistance = 0.25f;

    private float horizontal;
    
    public float maxLeftVelocity = -2f;
    public float maxRightVelocity = 2f;

    void Update()
    {
        horizontal = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontal = -1;
        if (Input.GetKey(KeyCode.RightArrow)) horizontal = +1;
        //rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
        rb.AddForce(new Vector2(horizontal * runSpeed * 2, 0), ForceMode2D.Force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, maxLeftVelocity, maxRightVelocity), rb.velocity.y);

        // —— 跳跃按键：DownArrow —— 
        if (Input.GetKeyDown(KeyCode.DownArrow) && CanJump())
        {
            // gravityScale>0 时 向上跳；gravityScale<0 时 向下跳
            Vector2 jumpDir = rb.gravityScale > 0 ? Vector2.up : Vector2.down;
            rb.AddForce(jumpDir * jumpForce, ForceMode2D.Impulse);
        }


        
    }

    bool CanJump()
    {
        // gravityScale>0 时 地面在脚下（世界向下），gravityScale<0 时 地面在“脚上”（世界向上）
        Vector2 rayDir = rb.gravityScale > 0 ? Vector2.down : Vector2.up;
        return Physics2D.Raycast(transform.position, rayDir, rayDistance, groundLayer);


    }

    // （可选）在 Scene 视图可视化地面检测射线
    void OnDrawGizmosSelected()
    {
        if (rb == null) return;
        Vector2 dir = rb.gravityScale > 0 ? Vector2.down : Vector2.up;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)dir * rayDistance);
    }
}
