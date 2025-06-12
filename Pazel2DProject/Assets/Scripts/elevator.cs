using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    [Tooltip("上下振动速度（频率）")]
    public float frequency = 1f;
    [Tooltip("振幅（最大偏移距离）")]
    public float amplitude = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Mathf.Sin 返回 -1～1 之间的值，用振幅放大，并平移到 0～2amplitude
        float yOffset = Mathf.Sin(Time.time * frequency * Mathf.PI * 2) * amplitude;
        transform.localPosition = startPos + Vector3.up * yOffset;
    }
}
