using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingRotate : MonoBehaviour
{
    public float rotationSpeed = 7200.0f;
    // Start is called before the first frame update
    void Start()
    {   
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * 360.0f * 800.0f);
    }
}
