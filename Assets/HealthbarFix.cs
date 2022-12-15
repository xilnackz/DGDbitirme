using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HealthbarFix : MonoBehaviour
{
    public AttributesManager atm;
    public int maxHealth = 100;
    public HealthBar HealthBar;
    public int currentHealth;
    void Start()
    {
        
        HealthBar.SetMaxHealth(maxHealth);   
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = 
        HealthBar.SetHealth(currentHealth);
    }
}
