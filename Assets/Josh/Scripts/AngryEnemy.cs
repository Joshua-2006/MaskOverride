using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryEnemy : Enemy
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
            gm.UpdateHealth(-2f);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 2;
        }
    }
}
