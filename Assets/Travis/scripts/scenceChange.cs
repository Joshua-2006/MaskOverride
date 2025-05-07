using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenceChange : MonoBehaviour
{
    public string levelName;
    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(levelName);
        }
    }
    public void ChangeSceneLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
