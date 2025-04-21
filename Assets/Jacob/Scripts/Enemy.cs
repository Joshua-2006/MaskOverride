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
    public GameObject hit;
    public float hitDelay;

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
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        if(health <= 0)
        {
            speed = 0;
            Destroy(gameObject);
        }

        var distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < range)
        {
            isInRange = true;
        }
        if (distance > range)
        {
            isInRange = false;
        }
        if (isInRange == true)
        {
            speed = setSpeed;
        }
        else
        {
            speed = 0;
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
}
