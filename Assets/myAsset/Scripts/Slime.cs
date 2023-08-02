using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    Animator animator;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;
    public float changeDirectionInterval = 3f;

    private Vector3 currentDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetRandomDirection();
        StartCoroutine(ChangeDirectionCoroutine());
    }

    void Update()
    {
        // 몬스터를 이동 방향으로 이동시킴
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // 몬스터가 이동 방향과 회전 방향을 모두 고려하여 회전
        if (currentDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(currentDirection, Vector3.up);
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
        }
    }

    IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionInterval);
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        // 랜덤한 방향 벡터 생성
        currentDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
