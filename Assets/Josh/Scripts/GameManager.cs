using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int ammo;
    public int health;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth(int healthAmount)
    {
        health = healthAmount;
    }
    public void Reload(int ammoAmount)
    {
        ammo = ammoAmount;
    }
    
}
