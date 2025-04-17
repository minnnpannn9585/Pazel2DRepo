using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Rigidbody2D rb;
    [Tooltip("左右移动速度")]
    public float runSpeed = 2f;
    [Tooltip("跳跃冲量（用 Impulse 模式）")]
    public float jumpForce = 5f;
    [Tooltip("地面判定层级")]
    public LayerMask groundLayer;
    [Tooltip("地面检测射线长度")]
    public float rayDistance = 0.25f;

    void Update()
    {
        // —— 水平输入 ——  
        float h = 0;
        if (Input.GetKey(KeyCode.A)) h = -1;
        if (Input.GetKey(KeyCode.D)) h = +1;
        rb.velocity = new Vector2(h * runSpeed, rb.velocity.y);

        // —— 跳跃 ——  
        if (Input.GetKeyDown(KeyCode.W) && CanJump())
        {
            // 根据当前 gravityScale 决定跳跃方向
            Vector2 jumpDir = rb.gravityScale > 0 ? Vector2.up : Vector2.down;
            rb.AddForce(jumpDir * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool CanJump()
    {
        // 如果 gravityScale 正，地面在脚下（世界坐标的下方）；
        // 如果 gravityScale 负，地面在脚上（世界坐标的上方），射线方向反转。
        Vector2 downDir = rb.gravityScale > 0 ? Vector2.down : Vector2.up;
        // 从脚底中心往“重力方向的反向”打一条短射线，看有没有碰到地面
        return Physics2D.Raycast(transform.position, downDir, rayDistance, groundLayer);
    }

    // （可选）在 Scene 视图中显示你的射线，方便调试
    void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;
        Vector2 dir = rb.gravityScale > 0 ? Vector2.down : Vector2.up;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)dir * rayDistance);
    }
}
