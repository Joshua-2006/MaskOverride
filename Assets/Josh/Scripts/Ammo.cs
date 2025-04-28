using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Gun gun;
    public GameManager gm;
    public GameObject interact;
    // Start is called before the first frame update
    public void Start()
    {
        gun = FindAnyObjectByType<Gun>();
        gm = FindAnyObjectByType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        interact.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetButton("Interact") && gun.name == "HandGun")
        {
            interact.SetActive(false);
            gun.reserves += 1;
            gm.UpdateReserves();
            gameObject.SetActive(false);
        }
        if (Input.GetButton("Interact") && gun.name == "Gun")
        {
            interact.SetActive(false);
            gun.reserves += 1;
            gm.UpdateReserves2();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
           
    }
}
