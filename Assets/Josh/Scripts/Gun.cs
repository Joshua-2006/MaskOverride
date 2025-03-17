using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject spawn;
    public Pickup gun;
    public float ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        ammo = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (gun.canShoot)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) && ammo != 0)
            {
                Instantiate(bullet, spawn.transform.position, bullet.transform.rotation);
                ammo -= 1;
            }
        }
    }
  

}
