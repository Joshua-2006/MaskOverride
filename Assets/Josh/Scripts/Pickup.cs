using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool canPickup;
    public GameObject attach;
    public Movement player;
    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == attach.transform.position)
        {
            transform.rotation = player.transform.rotation;
            transform.Rotate(0, 0, player.transform.rotation.z);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canPickup = true;
        }
        if(canPickup && Input.GetButton("Interact"))
        {
            transform.SetParent(player.cam.transform, true);
            transform.position = attach.transform.position;
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
            transform.position = attach.transform.position;
            transform.rotation = attach.transform.rotation;
            transform.SetParent(player.cam.transform, true);
            canShoot = true;
        }
    }
}
