using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSubtract : MonoBehaviour
{
    public GameManager gm;
    public Transform teleport;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.position = teleport.position;
            gm.UpdateHealth(-3);
        }
    }
}
