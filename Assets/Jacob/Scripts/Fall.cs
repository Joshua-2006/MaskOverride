using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Rigidbody rb;
    public float time;
    public float respawnDelay;
    public Transform originalPosition;
    public AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }


    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            StartCoroutine(Falling());
        }
    }
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(time);
        rb.isKinematic = false;
        rb.mass = 1000;
        yield return new WaitForSeconds(respawnDelay);
        rb.isKinematic = true;
        transform.position = originalPosition.position;
        transform.rotation = originalPosition.rotation;
    }
}
