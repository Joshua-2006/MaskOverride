using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

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
    public bool isTurnedAround;
    public float raycastDistance = 10f;
    public LayerMask interactableLayer;
    [Header("Health")]
    public GameManager gm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        if (gm.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            // Raycast hit an object
            // Get the object that was hit
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.name == "Cube (2)")
            {
                isTurnedAround = true;
            }
            else if (hitObject.name == "Canvas (4)")
            {
                isTurnedAround = true;
            }

        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
        rb.AddRelativeForce(Vector3.right * horizontal * speed * drag, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.forward * vertical * speed * drag, ForceMode.Impulse);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }
    }
}
