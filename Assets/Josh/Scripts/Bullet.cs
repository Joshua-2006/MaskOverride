using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private Movement gun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun = FindAnyObjectByType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1);
        
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(gun.transform.forward * speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
