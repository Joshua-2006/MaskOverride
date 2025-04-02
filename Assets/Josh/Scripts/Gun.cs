using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public Pickup gun;
    public GameManager gm;
    public float ammo;
    public bool reload;
    public float reserves;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gm.UpdateReserves();
        if(reserves < 0)
        {
            reserves = 0;
        }
        if (gun.canShoot && gm.ammo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }
        }
        if(gm.ammo < 0)
        {
            gun.canShoot = false;
        }
        else if(gm.ammo >0)
        {
            gun.canShoot = true;
        }

        if (Input.GetKey(KeyCode.R) && reload && reserves > 0 && gm.ammo >= 0 && ammo <=20)
        { 
            gm.Reload(10);
            gm.UpdateReserves();
            reserves -= 1;
        }    
        if(reserves > 0)
        {
            reload = true;
        }

    }
    
   public void Fire()  
    {
        gm.ammo -= 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        gm.UpdateAmmo();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

}
