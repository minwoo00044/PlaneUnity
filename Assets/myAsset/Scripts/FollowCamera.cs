using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    public float lerpTime;
    Vector3 velocity; 
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame

    private void LateUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    player = GameObject.FindGameObjectWithTag("Player");
        //}
        if (player != null)
        {
            //transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 2.0f);
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position, ref velocity, lerpTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, Time.deltaTime * 2.0f);
        }
        //if (player != null)
        //{
        //    //transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 2.0f);
        //    transform.position = player.transform.position;
        //}
    }
}
