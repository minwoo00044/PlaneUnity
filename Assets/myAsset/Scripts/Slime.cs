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
        animator.SetBool("isRun", true);
        SetRandomDirection();
        StartCoroutine(ChangeDirectionCoroutine());
    }

    void Update()
    {
        // Move the enemy in the current direction
        transform.Translate(currentDirection * moveSpeed * Time.deltaTime);

        // Calculate the rotation step
        float step = rotationSpeed * Time.deltaTime;

        // Calculate the new rotation towards the current direction
        Quaternion targetRotation = Quaternion.LookRotation(currentDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
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
        // Create a random direction vector
        currentDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
