using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Enemy target;
    public Movement player;
    public float range;
    public float speed = 5;
    public float setSpeed;
    public bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < range)
            isInRange = true;
        
        if(distance > range)
            isInRange = false;
        

        if (isInRange == true)
            speed = 5;
        
        else
            speed = 0;
    }
}
