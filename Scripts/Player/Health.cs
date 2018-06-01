using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Health : MonoBehaviour {
  

    public float health;
    public float currentHealth;

    public bool isDead;


    public void Awake()
    {
        isDead = false;
        currentHealth = health;
    }

    public void Update()
    {
        if(currentHealth <= 0)
        {
            isDead = true;

        }
    }

    public void TakeDamage(float value )
    {
        if(!isDead)
        {
            currentHealth -= value;
           
        }        

    }



}
