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
        gm = FindAnyObjectByType<GameManager>();
        
    }
    public void Update()
    {
        gun = FindAnyObjectByType<Gun>();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetButton("Interact"))
        {
            gun.reserves += 1;
            gm.UpdateReserves();
            gameObject.SetActive(false);
            ;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
           
    }
}
