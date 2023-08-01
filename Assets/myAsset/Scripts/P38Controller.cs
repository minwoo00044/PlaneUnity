using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P38Controller : MonoBehaviour
{
    public float rotateSpeed = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //x
        float pitch = Input.GetAxis("Vertical");
        //z
        float roll = Input.GetAxis("Horizontal");

        pitch = Mathf.Clamp(pitch, -1, 1);
        roll = Mathf.Clamp(roll, -1, 1);
        Vector3 rotation = new Vector3(-pitch, 0, -roll);

        transform.Rotate(rotation * Time.deltaTime * rotateSpeed);
    }
}
