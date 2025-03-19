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
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            enemyRb.AddForce(player.transform.forward * explosionPower, ForceMode.Impulse);
            gm.UpdateHealth(-1);
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
        }
    }
}
