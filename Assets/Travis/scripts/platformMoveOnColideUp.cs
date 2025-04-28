using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMoveOnColideUp : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float activatedSpeed = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = activatedSpeed;
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
