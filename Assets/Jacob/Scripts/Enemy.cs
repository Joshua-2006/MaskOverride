using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody enemyRb;
    public GameObject player;
    public float explosionPower;
    public int health;
    public bool p;
    public GameManager gm;
    public bool isInRange;
    public float range;
    public float setSpeed;
    public Animator anim;
    public float animSetter;
    public GameObject hit;
    public float hitDelay;
    public GameObject mask;
    public GameObject rock;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        
        if(health <= 0)
        {
            anim.SetInteger("AnimSetter", 1);
            isInRange = false;
            speed = 0f;
            Destroy(mask);
            enemyRb.mass = 1000000;
            StartCoroutine(RockSpawn());
        }

        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < range && health > 0)
        {
            isInRange = true;
        }
        if (distance > range && health > 0)
        {
            isInRange = false;
        }
        if (isInRange == true && health > 0)
        {
            speed = setSpeed;
            anim.SetInteger("AnimSetter", 2);
        }
        else if(isInRange == false && health > 0)
        {
            speed = 0;
            anim.SetInteger("AnimSetter", 0);
        }
        
    }
    protected virtual void FixedUpdate()
    {
        Vector3 move = (player.transform.position - transform.position).normalized;
        if(isInRange)
        {
            Vector3 movement = move * speed;
            enemyRb.velocity = new Vector3(movement.x,enemyRb.velocity.y, movement.z);
        }
        else
        {
            enemyRb.velocity = new Vector3(0, enemyRb.velocity.y, 0);
        }
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            enemyRb.rotation = Quaternion.Slerp(enemyRb.rotation, targetRotation, speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enemyRb.AddForce(player.transform.forward * explosionPower, ForceMode.Impulse);
            gm.UpdateHealth(-1);
            StartCoroutine(Hit());
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 3;
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
        yield return new WaitForSeconds(.5f);
        rock.SetActive(true);
        Destroy(gameObject, 3);
    }
}
