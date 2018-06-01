using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damageAmount = 10;
    private GameObject player;
    private Health health;
    private Health PlayerHealth;
    private bool playerInRange;
    public float timeBetwenAttacks = 1f;
    float timer;
    private PrzeciwnikMovement przeciwnikMovement;




    public void Awake()
    {
        playerInRange = false;
       player = GameObject.FindGameObjectWithTag(Tags.Player);

        if (PlayerHealth != null)
            PlayerHealth = player.GetComponent<Health>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if(timer <= timeBetwenAttacks && playerInRange && PlayerHealth.currentHealth > 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        timer = 0f;

        if(PlayerHealth.currentHealth > 0)
        {
            PlayerHealth.TakeDamage(damageAmount);
        }
    }




    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        playerInRange = false;
    }




}
