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
            gm.UpdateHealth(-2f);
            StartCoroutine(Hit());
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= 2;
            if (health <= 0)
            {
                ac.PlayOneShot(ap);
                bc.isTrigger = true;
                anim.SetInteger("AnimSetter", 1);
                isInRange = false;
                speed = 0f;
                Destroy(mask);
                Destroy(gameObject, 1);
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
