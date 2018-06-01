 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    
    private Animator anim;
    private HaszIDs hash;

     void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HaszIDs>();


        anim.SetLayerWeight(2, 1f);
        anim.SetLayerWeight(3, 1f);
    }

    void Update()
    {
        bool shoot = Input.GetButton(Inputs.fire1);

       ShootingManager(shoot);
    }

    void ShootingManager(bool shoot)
    {
      
            anim.SetBool(hash.isShooting, shoot);
       


    }

}
