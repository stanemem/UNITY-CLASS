using System;
using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Vector3 topPosition = new Vector3(-9f, 5f, 0f);    // 위쪽 도착 좌표
    public Vector3 bottomPosition = new Vector3(-9f, -2f, 0f); // 아래쪽 도착 좌표
    public float moveSpeed = 2f; // 이동 속도

    IEnumerator MoveRoutine()
    {
        transform.position = bottomPosition;

        while (true)
        {
            // 1. 아래 → 위로 이동
            while (Vector3.Distance(transform.position, topPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, topPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // 2. 위 → 아래로 이동
            while (Vector3.Distance(transform.position, bottomPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
