using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        StartCoroutine(Fall());
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(3);
        rb.isKinematic = false;
        rb.mass = 10000000000000;
    }
}
