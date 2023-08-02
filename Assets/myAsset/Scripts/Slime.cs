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
        // ���͸� �̵� �������� �̵���Ŵ
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // ���Ͱ� �̵� ����� ȸ�� ������ ��� ����Ͽ� ȸ��
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
        // ������ ���� ���� ����
        currentDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
