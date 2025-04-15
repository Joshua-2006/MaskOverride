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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gm.UpdateHealth(-3);
            if (CheckPointStorage.currentCheckPoint == null)
            {
                player.position = teleport.position;
            }
            else
            {
                player.position = CheckPointStorage.currentCheckPoint.position;
            }
        }
    }
}
