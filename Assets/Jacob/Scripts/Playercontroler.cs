using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroler : MonoBehaviour
{

    private float speed = 5.0f;
    public float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    [Header("shooting")]
    public GameObject bullet;
    public GameObject bulletSpawn;
    private Rigidbody rb;
    public bool isOnGround;
    public float jumpForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
    }
    void Update()
    {
        // Axis setup
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotate the playerleft and right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //shooting
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        }
        //Jumping
        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
