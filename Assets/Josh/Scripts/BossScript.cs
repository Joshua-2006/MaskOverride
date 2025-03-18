using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : Enemy
{
    public Slider slider;
    public int hurtAmount;
    public int hp;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
    
}
