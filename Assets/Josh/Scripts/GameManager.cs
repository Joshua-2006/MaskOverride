using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int ammo;
    public float health;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI reservesText;
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealth(float healthAmount)
    {
        health += healthAmount;
        healthText.text = $"Health: {health}";
    }
    public void Reload(int ammoAmount)
    {
        ammo += ammoAmount;
        ammoText.text = $"{ammo}";
    }
    public void UpdateAmmo()
    {
        ammoText.text = $"{ammo}";
    }
    public void UpdateReserves()
    {
        reservesText.text = $"{gun.reserves}";
    }
    
}
