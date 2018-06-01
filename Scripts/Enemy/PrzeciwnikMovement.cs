

using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class PrzeciwnikMovement : MonoBehaviour {
    public float DeadZone = 5f;


    private NavMeshAgent nav;
    private GameObject player;
    private Animator anim;
    private HaszIDs hash;
    private SphereCollider sCollider;
    private  bool enemyAnimIsDead;
    private Health health;

    private CapsuleCollider cColider;


    void Awake()
        {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        sCollider = GetComponent<SphereCollider>();
        health = GetComponent<Health>();
        cColider = GetComponent<CapsuleCollider>();

        player = GameObject.FindGameObjectWithTag(Tags.Player);
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HaszIDs>();
        enemyAnimIsDead = true;

        }

     void Update(){
        if(health.currentHealth > 0)
        {

        } else
        {
            DeathAnimation();
        }
    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            MovementManager();
        }
       
    }
     void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            StopAnimation();
        }
    }

    public void DeathAnimation()
    {
        if (enemyAnimIsDead)
        {
            anim.SetTrigger(hash.isDead);
            cColider.isTrigger = true;
            enemyAnimIsDead = false;
        }

    }

      public  void StopAnimation()
    {
        anim.SetFloat(hash.enemySpeed, 0f);
        nav.speed = 0f;

    }


    void MovementManager(float speed = 0, float angle = 0)
    {
        
        nav.SetDestination(player.transform.position);
        anim.SetFloat(hash.enemySpeed, 1.25f);
        nav.speed = anim.GetFloat(hash.enemySpeed);
       
    }

}
