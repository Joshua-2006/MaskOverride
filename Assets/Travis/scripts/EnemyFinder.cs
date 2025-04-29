using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public int enemiesLeft;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = GameObject.FindGameObjectsWithTag("zone1").Length;
        platform.SetActive(false);
    }

    public void UpdateEnemies()
    {
        StartCoroutine(DelayedEnemyCount());
    }

    IEnumerator DelayedEnemyCount()
    {
        yield return new WaitForSeconds(2.1f);
        enemiesLeft = GameObject.FindGameObjectsWithTag("zone1").Length;
        if (enemiesLeft <= 0)
        {
            EnemiesAllGone();
        }
    }

    public void EnemiesAllGone()
    {
        platform.SetActive(true);
    }
}
