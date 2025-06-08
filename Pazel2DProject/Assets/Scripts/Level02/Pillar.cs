using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [Header("下砸参数")]
    public float smashSpeed = 15f;      // 下砸速度
    public float returnSpeed = 5f;      // 回升速度
    public float delayBetweenPillars = 0.5f; // 柱子间的延迟
    public float delayBetweenCycles = 1f;    // 完整循环后的间隔

    [Header("柱子配置")]
    public Transform[] pillars;         // 拖入3个柱子的Transform
    private Vector3[] originalPositions;

    void Start()
    {
        // 记录初始位置
        originalPositions = new Vector3[pillars.Length];
        for (int i = 0; i < pillars.Length; i++)
        {
            originalPositions[i] = pillars[i].position;
        }

        // 开始自动循环
        StartCoroutine(InfiniteSmashLoop());
    }

    // 无限循环协程
    System.Collections.IEnumerator InfiniteSmashLoop()
    {
        while (true) // 无限循环
        {
            // 依次下砸所有柱子
            for (int i = 0; i < pillars.Length; i++)
            {
                yield return StartCoroutine(SmashPillar(pillars[i], originalPositions[i]));
                if (i < pillars.Length - 1) // 最后一个柱子后不等待
                {
                    yield return new WaitForSeconds(delayBetweenPillars);
                }
            }

            // 完整循环后的停顿
            yield return new WaitForSeconds(delayBetweenCycles);
        }

        System.Collections.IEnumerator SmashPillar(Transform pillar, Vector3 originalPos)
        {
            Vector3 targetPos = originalPos + Vector3.down * 5f; // 下砸距离

            // 下砸阶段
            while (pillar.position.y > targetPos.y)
            {
                pillar.position += Vector3.down * smashSpeed * Time.deltaTime;
                yield return null;
            }

            // 短暂停顿（可调整）
            yield return new WaitForSeconds(0.1f);

            // 回升阶段
            while (pillar.position.y < originalPos.y)
            {
                pillar.position += Vector3.up * returnSpeed * Time.deltaTime;
                yield return null;
            }

            pillar.position = originalPos; // 确保精确复位
        }
    }
}
