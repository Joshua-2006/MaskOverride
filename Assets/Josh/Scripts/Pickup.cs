using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool canPickup;
    public float shootDelay;
    public Movement player;
    public bool canShoot;
    public Pickup gun;
    public Pickup gun2;
    public Pickup Pistol;
    public Pickup Rifle;
   
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(canPickup && Input.GetButton("Interact") && this.name == "Pistol")
        {
            Rifle.gameObject.SetActive(true);
            gameObject.SetActive(false);
            gun.canShoot = true;
            gun.gameObject.SetActive(true);
            gun2.gameObject.SetActive(false);
            gun2.canShoot = false;
            
        }
        if (canPickup && Input.GetButton("Interact") && this.name == "Rifle")
        {
            Pistol.gameObject.SetActive(true);
            gameObject.SetActive(false);
            gun.canShoot = false;
            gun.gameObject.SetActive(false);
            gun2.canShoot = true;
            gun2.gameObject.SetActive(true);
        }
    }
}
