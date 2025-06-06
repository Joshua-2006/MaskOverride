using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEnemy : Enemy
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void OnCollisionExit(Collision collision)
    {
        base.OnCollisionExit(collision);
    }
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GetBack());
            gm.UpdateHealth(-1f);
            StartCoroutine(Hit());
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            if (health <= 0)
            {
               
                ac.PlayOneShot(ap);
                bc.isTrigger = true;
                anim.SetInteger("AnimSetter", 1);
                isInRange = false;
                speed = 0f;
                Destroy(mask);
                Destroy(gameObject, 1);
                enemyFinder.UpdateEnemies();
            }
        }
    }
    IEnumerator Hit()
    {
        hit.SetActive(true);
        yield return new WaitForSeconds(hitDelay);
        hit.SetActive(false);
    }
  
    protected override IEnumerator GetBack()
    {
        return base.GetBack();
    }
}
