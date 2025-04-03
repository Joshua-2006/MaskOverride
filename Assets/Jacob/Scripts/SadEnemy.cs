using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadEnemy : Enemy
{


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyRb.AddForce(player.transform.forward * explosionPower, ForceMode.Impulse);
            gm.UpdateHealth(-0.5f);
            gm.Reload(-5);
        }
    }
}
