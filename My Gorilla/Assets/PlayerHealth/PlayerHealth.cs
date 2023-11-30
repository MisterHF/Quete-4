using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth;

    public HealthBar healthBar;
    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) 
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        curHealth = curHealth - damage;
        healthBar.SetHealth(curHealth);
    }
}
