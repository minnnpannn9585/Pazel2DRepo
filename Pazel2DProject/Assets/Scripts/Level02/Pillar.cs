using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [System.Serializable]
    public class PillarGroup
    {
        public Transform[] pillars;
        public Vector3 moveDirection = Vector3.down; // 控制方向
        public float moveDistance = 0.46f;
        [HideInInspector] public Vector3[] originalPositions;
    }

    [Header("下砸参数")]
    public float smashSpeed = 15f;
    public float returnSpeed = 5f;
    public float delayBetweenPillars = 0.5f;
    public float delayBetweenCycles = 1f;

    [Header("柱子分组")]
    public PillarGroup[] pillarGroups; // 第一组向下，第二组向上

    void Start()
    {
        // 初始化所有组
        foreach (var group in pillarGroups)
        {
            group.originalPositions = new Vector3[group.pillars.Length];
            for (int i = 0; i < group.pillars.Length; i++)
            {
                group.originalPositions[i] = group.pillars[i].position;
            }
        }

        StartCoroutine(InfiniteSmashLoop());
    }

    System.Collections.IEnumerator InfiniteSmashLoop()
    {
        while (true)
        {
            // 每组柱子依次运动
            foreach (var group in pillarGroups)
            {
                for (int i = 0; i < group.pillars.Length; i++)
                {
                    yield return StartCoroutine(MovePillar(
                        group.pillars[i],
                        group.originalPositions[i],
                        group.moveDirection,
                        group.moveDistance
                    ));
                    
                    if (i < group.pillars.Length - 1)
                    {
                        yield return new WaitForSeconds(delayBetweenPillars);
                    }
                }
            }
            yield return new WaitForSeconds(delayBetweenCycles);
        }
    }

    System.Collections.IEnumerator MovePillar(Transform pillar, Vector3 originalPos, Vector3 direction, float distance)
    {
        Vector3 targetPos = originalPos + direction * distance;

        // 运动阶段（下砸/上冲）
        while (Vector3.Distance(pillar.position, targetPos) > 0.1f)
        {
            pillar.position = Vector3.MoveTowards(
                pillar.position,
                targetPos,
                smashSpeed * Time.deltaTime
            );
            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        // 返回阶段
        while (Vector3.Distance(pillar.position, originalPos) > 0.1f)
        {
            pillar.position = Vector3.MoveTowards(
                pillar.position,
                originalPos,
                returnSpeed * Time.deltaTime
            );
            yield return null;
        }

        pillar.position = originalPos;
    }
}