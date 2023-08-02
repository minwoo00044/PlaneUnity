using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    Vector3 moveDir;
    public float moveSpeed = 5f;
    public float rotationSpeed = 90f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationInputX = Input.GetAxis("Mouse X");
        //float rotationInputY = Input.GetAxis("Mouse Y");
        moveDir = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDir.Normalize();
        if(!animator.GetBool("isAttack"))
        {
            Vector3 moveOffset = moveDir * (moveSpeed * Time.deltaTime);
            rb.MovePosition(rb.position + moveOffset);
        }


        // È¸Àü
        float rotationAmount = rotationInputX * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);

        float currentSpeed = moveDir.magnitude * moveSpeed;
        animator.SetFloat("moveSpeed", currentSpeed);
    }



}
