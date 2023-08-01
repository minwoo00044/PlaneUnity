using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P38Movement : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float factor = Input.GetAxis("Fire1") * 5.0f;
        transform.Translate(Vector3.forward * moveSpeed * factor * Time.deltaTime);
        //if (Input.GetButton("Fire1"))
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * 5 * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
    }
}
