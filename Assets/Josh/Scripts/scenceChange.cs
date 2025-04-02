using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenceChange : MonoBehaviour
{
    public void ChangeSceneLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
