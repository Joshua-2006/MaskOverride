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
        sad = FindAnyObjectByType<SadEnemy>();        
        gm.UpdateReserves2();
        if (reserves < 0)
        {
            reserves = 0;
        }


        //This code is dogwater
   /*     if (gun.canShoot && gm.gunAmmos > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                StartCoroutine(Wait());
            }
        }*/

        if(Input.GetButton("Fire1") && gun.canShoot && gm.gunAmmos > 0)
        {
            Fire();
        }

        if (gm.gunAmmos <= 0 && sad != null) 
        {
            gun.canShoot = false;
            sad.sad = false;
        }
        if(gm.gunAmmos > 0 && sad != null)
        {
            sad.sad = false;
        }

        if (Input.GetKey(KeyCode.R) && reload && reserves > 0 && gm.gunAmmos == 0 && ammo < 200)
        {
            gm.Reloads(200);
            gm.UpdateReserves2();
            reserves -= 1;
            reload = false;
            reloads.SetActive(false);
        }
        if (reserves > 0)
        {
            reload = true;
        }
        if (reserves == 0)
        {
            reload = false;
        }
        if (reload && gm.gunAmmos == 0)
        {
            reloads.SetActive(true);
        }
        if (reload == false && gm.gunAmmos > 0)
            reloads.SetActive(false);
    }

    protected override void Fire()
    {
        audios.PlayOneShot(shoot);
        gun.canShoot = false;
        StartCoroutine(ResetGun());
        gm.gunAmmos -= 1;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        gm.UpdateAmmo2();

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
    }
    IEnumerator ResetGun()
    {
        yield return new WaitForSeconds(gun.shootDelay);
        gun.canShoot = true;
    }
}
