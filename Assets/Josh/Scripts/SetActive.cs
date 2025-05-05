using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public Gun target;
    public Gun target2;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && target != null && target2 != null && target2.isActiveAndEnabled)
        {
            target.gameObject.SetActive(true);
            target2.gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("Player") && target != null && target2 != null && target.isActiveAndEnabled)
        {
            target2.gameObject.SetActive(true);
            target.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Player") && ps != null)
        {
            ps.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && ps != null)
        {
            ps.Stop();
        }
    }
}
