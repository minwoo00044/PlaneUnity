using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public float bulletCoolTime;
    public bool canShoot = true;

    public MissilePoint[] firePoint;
    // Start is called before the first frame update
    void Awake()
    {
        firePoint = gameObject.GetComponentsInChildren<MissilePoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            StartCoroutine(LateFire());
        }
    }

    private IEnumerator LateFire()
    {
        canShoot = false;
        yield return new WaitForSeconds(bulletCoolTime);
        for(int i = 0; i < firePoint.Length; i++) 
        {
            Instantiate(bullet, firePoint[i].transform.position, firePoint[i].transform.rotation);
        }
        canShoot = true;
    }
}
