using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform healthbar;
    public int maxHealth = 100;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<=0)
        {
            health = 0;

        }
        healthbar.localScale = new Vector3((float)health / maxHealth, 1, 1);
    }

}
