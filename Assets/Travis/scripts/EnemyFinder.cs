using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public int enemiesLeft;


    // Start is called before the first frame update
    void Start()
    {
        enemiesLeft = GameObject.FindObjectsByType<Enemy>(0).Length;
    }

    public void UpdateEnemies()
    {
        StartCoroutine(DelayedEnemyCount());
    }

    IEnumerator DelayedEnemyCount()
    {
        yield return new WaitForSeconds(2.1f);
        enemiesLeft = GameObject.FindObjectsByType<Enemy>(0).Length;
        if (enemiesLeft <= 0)
        {
            EnemiesAllGone();
        }
    }

    public void EnemiesAllGone()
    {
        Debug.Log("you have killed them all");
    }
}
