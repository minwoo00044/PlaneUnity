using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 30.0f;

    public GameObject cubePlane;
    public GameObject F15C;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        { 
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.back);
        }

        //if(Input.GetKeyDown(KeyCode.C))
        //{
        //    if(cubePlane.activeSelf)
        //    {
        //        F15C.transform.position = cubePlane.transform.position;
        //        cubePlane.SetActive(false);
        //        F15C.SetActive(true);
                
        //    }
        //    else
        //    {
        //        cubePlane.transform.position = F15C.transform.position;
        //        cubePlane.SetActive(true);
        //        F15C.SetActive(false);
                
        //    }
        //}
    }
}
