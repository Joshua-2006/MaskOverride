using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Movement player;
    public Rigidbody rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Movement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(player.transform.forward * speed);
        }
    }
    private void FixedUpdate()
    { 
    }
}
