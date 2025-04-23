using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider health;
    public int ammo;
    public int gunAmmos;
    //public float health;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI gunAmmo;
    public TextMeshProUGUI gunReserves;
    public TextMeshProUGUI reservesText;
    public Gun gun;
    public Gun rifle;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Reload(10); 
    }
    public void UpdateHealth(float healthAmount)
    {
        health.value += healthAmount;
    }
    public void Reload(int ammoAmount)
    {
        ammo += ammoAmount;
        ammoText.text = $"{ammo}";
    }
    public void Reloads(int ammoAmount)
    {
        gunAmmos += ammoAmount;
        gunAmmo.text = $"{gunAmmos}";
    }
    public void UpdateAmmo()
    {
        ammoText.text = $"{ammo}";
    }
    public void UpdateAmmo2()
    {
        gunAmmo.text = $"{gunAmmos}";
    }
    public void UpdateReserves()
    {
        reservesText.text = $"{gun.reserves}";
    }
    public void UpdateReserves2()
    {
        gunReserves.text = $"{rifle.reserves}";
    }
    
}
