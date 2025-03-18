using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool canPickup;
    public GameObject attach;
    public Movement player;
    public bool canShoot;
    public Pickup gun;
   
    
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
        if(canPickup && Input.GetButton("Interact"))
        {
            gameObject.SetActive(false);
            gun.canShoot = true;
            gun.gameObject.SetActive(true);
            
        }
    }
}
