using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadEnemy : Enemy
{
    

    // Update is called once per frame
     protected override void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gm.Reload(-5);
        }
    }
}
