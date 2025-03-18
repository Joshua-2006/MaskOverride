using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private float xChange = 0;
    private float yChange = 0;
    private float zChange = 0;

    public bool isXMoving;
    public bool isXUsingSine;
    public float xAmp;
    public float xPeriod;

    public bool isYMoving;
    public bool isYUsingSine;
    public float yAmp;
    public float yPeriod;

    public bool isZMoving;
    public bool isZUsingSine;
    public float zAmp;
    public float zPeriod;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isXMoving)
        {
            xChange = WaveMove(xAmp, xPeriod, isXUsingSine);
        }
        if (isYMoving)
        {
            yChange = WaveMove(yAmp, yPeriod, isYUsingSine);
        }
        if (isZMoving)
        {
            zChange = WaveMove(zAmp, zPeriod, isZUsingSine);
        }

        transform.position = new Vector3(startPosition.x + xChange, startPosition.y + yChange, startPosition.z + zChange);
    }

    public float WaveMove(float amp, float period, bool isUsingSine)
    {
        if (period !=0)
        {
            if (isUsingSine)
            {
                return amp * Mathf.Sin(Time.time * (6.28f / period));
            }
            else
            {
                return amp * Mathf.Cos(Time.time * (6.28f / period));
            }
        }
        else
        {
            return 0;
        }
    }

}
