using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.CompareTag("Player"))
        {
            CheckPointStorage.currentCheckPoint = transform;
            gameObject.SetActive(false);
        }
    }
}
