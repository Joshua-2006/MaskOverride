using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Gun gun;
    // Start is called before the first frame update
    public void Start()
    {
               
    }
    public void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetButton("Interact"))
        {
            gun.reload = true;
            gameObject.SetActive(false);
        }
    }
}
