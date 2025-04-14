using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerCheckPointMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    if(CheckPointStorage.currentCheckPoint != null)
        {
            transform.position = CheckPointStorage.currentCheckPoint.position;
        }
    }

    
}
