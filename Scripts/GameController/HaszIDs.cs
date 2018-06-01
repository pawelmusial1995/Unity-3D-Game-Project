using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaszIDs : MonoBehaviour {

    [HideInInspector]
    public int speed,
        isDead,
        isShouting,
        isShooting,
        enemySpeed,
        shot;
        



    void Awake()
    {
    speed = Animator.StringToHash("Speed");
    isDead = Animator.StringToHash("IsDead");
    isShouting = Animator.StringToHash("IsShouting");
    isShooting = Animator.StringToHash("IsShooting");
    enemySpeed = Animator.StringToHash("EnemySpeed");
    shot = Animator.StringToHash("Shot");

    }


}