using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveOnColide : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float activatedSpeed = 10;
    [SerializeField] private float stoppingX;

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
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < stoppingX)
        {
            activatedSpeed = 0;
            speed = activatedSpeed;
            
        }
    }
}
