using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Gun gun;
    public GameManager gm;
    // Start is called before the first frame update
    public void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
        
    }
    public void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetButton("Interact"))
        {
            gun.reserves += 1;
            gm.UpdateReserves();
            gameObject.SetActive(false);
        }
    }
}
