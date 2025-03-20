using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject text;
    public GameObject text2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Destroy(wall);
            text.SetActive(false);
            text2.SetActive(true);
        }
    }
}
