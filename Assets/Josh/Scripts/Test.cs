using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject bow;
    public Sprite sprite;
    private void Update()
    {
        bow.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
