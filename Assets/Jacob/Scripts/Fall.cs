using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Rigidbody rb;
    public float time;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Falling());
        }
    }
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(time);
        rb.isKinematic = false;
        rb.mass = 1000;
    }
}
