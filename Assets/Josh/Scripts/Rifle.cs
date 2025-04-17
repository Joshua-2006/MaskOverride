using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        gm.UpdateReserves2();
        if (reserves < 0)
        {
            reserves = 0;
        }
        if (gun.canShoot && gm.gunAmmos > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Fire();
            }
        }
        if (gm.gunAmmos <= 0)
        {
            gun.canShoot = false;
            //sad.sad = false;

        }
        else if (gm.gunAmmos > 0)
        {
            gun.canShoot = true;

            //sad.sad = true;
        }

        if (Input.GetKey(KeyCode.R) && reload && reserves > 0 && gm.gunAmmos >= 0)
        {
            gm.Reloads(200);
            gm.UpdateReserves2();
            reserves -= 1;
            reload = false;
        }
        if (reserves > 0)
        {
            reload = true;
        }
        if (reserves == 0)
        {
            reload = false;
        }
        if (reload)
        {
            reloads.SetActive(true);
        }
        if (reload == false)
            reloads.SetActive(false);
    }

    protected override void Fire()
    {
        gm.gunAmmos -= 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        gm.UpdateAmmo2();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
}
