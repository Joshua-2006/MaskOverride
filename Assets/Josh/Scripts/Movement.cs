using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float horizontal;
    public float vertical;
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float drag;
    public bool isGrounded;
    [Header("Camera")]
    public GameObject target;
    public Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        rb.AddRelativeForce(Vector3.right * horizontal * speed * drag, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.forward * vertical * speed * drag, ForceMode.Impulse);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }
    }
}
