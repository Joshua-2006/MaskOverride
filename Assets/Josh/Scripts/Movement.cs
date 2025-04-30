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
    public GameObject e;
    [Header("Health")]
    public GameManager gm;
    [Header("Audio")]
    public AudioSource audios;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip death;
    public bool isWalking;

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audios.PlayOneShot(jump);
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
       /* if (isGrounded == false)
            rb.mass = 50;
        if (isGrounded)
            rb.mass = 2;*/
        if (gm.health.value <= 0)
        {
            StartCoroutine(Death());
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            e.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Interactable"))
        {
            e.SetActive(false);
        }
    }
    IEnumerator Death()
    {
        audios.PlayOneShot(death);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
