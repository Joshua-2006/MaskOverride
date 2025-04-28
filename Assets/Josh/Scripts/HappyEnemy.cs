using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyRb.AddForce(player.transform.forward * explosionPower, ForceMode.Impulse);
            gm.UpdateHealth(-1f);
            StartCoroutine(Hit());
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            if (health <= 0)
            {
                anim.SetInteger("AnimSetter", 1);
                isInRange = false;
                speed = 0f;
                Destroy(mask);
                enemyRb.mass = 1000000;
                StartCoroutine(RockSpawn());
            }
        }
    }
    IEnumerator Hit()
    {
        hit.SetActive(true);
        yield return new WaitForSeconds(hitDelay);
        hit.SetActive(false);
    }
    IEnumerator RockSpawn()
    {
        yield return new WaitForSeconds(1.6f);
        rock.SetActive(true);
        enemyFinder.UpdateEnemies();
        Destroy(gameObject, 2);

    }
}
