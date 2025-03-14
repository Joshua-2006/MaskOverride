using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gun = FindAnyObjectByType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
       // Destroy(gameObject, 1);
    }
    private void FixedUpdate()
    {
        transform.Translate(gun.transform.forward * Time.deltaTime * speed);
    }
}
