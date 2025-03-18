using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
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
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
    }
   public void Fire()  
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

}
