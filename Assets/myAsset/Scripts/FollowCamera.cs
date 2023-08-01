using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
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
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -60f);
        }
    }
}
