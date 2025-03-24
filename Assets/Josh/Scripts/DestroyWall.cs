using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject text;
    public GameObject text2;
    public Movement player;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.rotation == target.transform.rotation)
        {
            player.isTurnedAround = true;
        }
        if(Input.GetButtonDown("Jump") && player.isTurnedAround)
        {
            Destroy(wall);
            text.SetActive(false);
            text2.SetActive(true);
        }
    }
}
