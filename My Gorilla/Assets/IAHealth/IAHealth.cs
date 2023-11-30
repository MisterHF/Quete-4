using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int curHealth;

    public HealthBarIA healthBar;
    void Start()
    {
        curHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) 
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
