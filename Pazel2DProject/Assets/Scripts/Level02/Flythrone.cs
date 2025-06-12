using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [System.Serializable]
    public class SpikeGroup
    {
        public Transform[] spikes;          // 三角锥数组
        public Vector3 moveDirection;      // 移动方向 (下:Vector3.down, 左:Vector3.left, 右:Vector3.right)
        public float moveDistance = 5f;    // 移动距离
        public float moveSpeed = 15f;      // 移动速度
        [HideInInspector] public Vector3[] originalPositions;
    }

    [Header("分组设置")]
    public SpikeGroup[] spikeGroups; // 顺序配置：0=下砸组, 1=左飞组, 2=右飞组

    [Header("通用参数")]
    public float resetDelay = 0.85f;          // 重置前的延迟
    public float delayBetweenSpikes = 0.3f;// 同组三角锥间隔
    public float delayBetweenCycles = 0.8f;  // 完整循环间隔

    [Header("效果")]
    public ParticleSystem impactEffect;
    public AudioClip movementSound;

    void Start()
    {
        // 初始化所有组
        foreach (var group in spikeGroups)
        {
            group.originalPositions = new Vector3[group.spikes.Length];
            for (int i = 0; i < group.spikes.Length; i++)
            {
                group.originalPositions[i] = group.spikes[i].position;
            }
        }

        StartCoroutine(MovementCycle());
    }

    System.Collections.IEnumerator MovementCycle()
    {
        while (true)
        {
            // 每组依次触发
            foreach (var group in spikeGroups)
            {
                // 同组三角锥依次移动
                for (int i = 0; i < group.spikes.Length; i++)
                {
                    StartCoroutine(MoveSpike(
                        group.spikes[i],
                        group.originalPositions[i],
                        group.moveDirection,
                        group.moveDistance,
                        group.moveSpeed
                    ));
                    yield return new WaitForSeconds(delayBetweenSpikes);
                }

                // 等待本组所有三角锥完成移动
                yield return new WaitForSeconds(group.moveDistance / group.moveSpeed + resetDelay);
            }

            // 完整循环后的延迟
            yield return new WaitForSeconds(delayBetweenCycles);
        }
    }

    System.Collections.IEnumerator MoveSpike(Transform spike, Vector3 originalPos, Vector3 direction, float distance, float speed)
    {
        Vector3 targetPos = originalPos + direction * distance;

        // 移动阶段
        while (Vector3.Distance(spike.position, targetPos) > 0.1f)
        {
            spike.position = Vector3.MoveTowards(spike.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        // 播放效果
        if (impactEffect) Instantiate(impactEffect, spike.position, Quaternion.identity);
        if (movementSound) AudioSource.PlayClipAtPoint(movementSound, spike.position);

        // 隐藏三角锥
        spike.gameObject.SetActive(false);
        yield return new WaitForSeconds(resetDelay);

        // 重置
        spike.position = originalPos;
        spike.gameObject.SetActive(true);
    }

    // 可视化调试
    void OnDrawGizmosSelected()
    {
        if (spikeGroups == null) return;

        foreach (var group in spikeGroups)
        {
            if (group.spikes == null || group.spikes.Length == 0) continue;

            Gizmos.color = GetDirectionColor(group.moveDirection);
            for (int i = 0; i < group.spikes.Length; i++)
            {
                if (group.spikes[i] != null)
                {
                    Vector3 startPos = Application.isPlaying && group.originalPositions != null ? 
                                      group.originalPositions[i] : group.spikes[i].position;
                    Vector3 endPos = startPos + group.moveDirection * group.moveDistance;
                    Gizmos.DrawLine(startPos, endPos);
                    Gizmos.DrawWireSphere(endPos, 0.3f);
                }
            }
        }
    }

    Color GetDirectionColor(Vector3 dir)
    {
        if (dir == Vector3.down) return Color.red;
        if (dir == Vector3.left) return Color.blue;
        if (dir == Vector3.right) return Color.green;
        return Color.white;
    }
}
