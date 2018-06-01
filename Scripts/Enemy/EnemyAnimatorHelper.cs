using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorHelper
{

    public float speedDumpTime = 0.1f;
    public float angularSpeedDumpTime = 0.7f;
    public float angleResponseTime = 0.6f;


    private Animator anim;
    private HaszIDs hash;

    public EnemyAnimatorHelper(Animator animator, HaszIDs hashID)
    {

        anim = animator;
        hash = hashID;

    }

    public void Setup(float speed, float angle)
    {

        float angularSpeed = angle / angleResponseTime;

        anim.SetFloat(hash.enemySpeed, speed, angularSpeedDumpTime, Time.deltaTime);
    }

	
}
