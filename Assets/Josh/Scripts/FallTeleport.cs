using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTeleport : MonoBehaviour
{
    public Transform teleport;
    public Transform fall;
    // Start is called before the first frame update
    void Start()
    {
        teleport.position = fall.position;
        teleport.rotation = fall.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
