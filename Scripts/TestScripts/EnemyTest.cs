using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

    [Range(0, 5)]
    public float speed = 0;

    private Animator anim;
    private HaszIDs hash;


     void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HaszIDs>();

    }

     void FixedUpdate()
    {
        MovementManageer(speed);
    }

    void MovementManageer(float speed)
    {
       
            anim.SetFloat(hash.enemySpeed, speed);
      
    }
}
