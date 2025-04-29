using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyFinder enemyFinder;

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
    public bool isGrounded;
    public BoxCollider bc;
    public AudioSource ac;
    public AudioClip ap;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gm = FindAnyObjectByType<GameManager>();
        enemyFinder = GameObject.Find("EnemyFinder").GetComponent<EnemyFinder>();
        bc = GetComponent<BoxCollider>();
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   protected virtual void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < range && health > 0)
        {
            isInRange = true;
        }
        else if (distance > range && health > 0 || isGrounded == false)
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
    
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GetBack());
            gm.UpdateHealth(-1);
            StartCoroutine(Hit());
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 3;
            if (health <= 0)
            {
                enemyFinder.UpdateEnemies();
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
    protected virtual void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Grounded"))
        {
            isGrounded = false;
            StartCoroutine(Fall());
        }
    }
    IEnumerator Hit()
    {
        hit.SetActive(true);
        yield return new WaitForSeconds(hitDelay);
        hit.SetActive(false);
    }
  
    protected virtual IEnumerator GetBack()
    {
        transform.Translate(player.transform.forward * explosionPower);
        yield return new WaitForSeconds(0.5f);
        transform.Translate(player.transform.forward * 0);
    }
    protected virtual IEnumerator Fall()
    {
        yield return new WaitForEndOfFrame();
        /*transform.Translate(Vector3.down * explosionPower);
        Destroy(gameObject, 1);*/
    }
}
