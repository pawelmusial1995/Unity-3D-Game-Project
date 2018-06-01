using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerShootingKill : MonoBehaviour {
    public float weaponStrenght = 10; 
    public LayerMask mask;
    public Transform whiteRabbit;

    private Animator anim;
    private HaszIDs hash;
    private bool shoot;
    private AudioSource ShotAudio;
 

    public void Awake()
    {
        anim = GetComponentInParent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HaszIDs>();
        ShotAudio = GetComponent<AudioSource>();
        shoot = false;
    }


    public void Update()
    {
         shoot = Input.GetButton(Inputs.fire1);
        
        Attack(shoot);
    }
    RaycastHit hit;

    private void Attack(bool shoot)
    {

        anim.SetBool(hash.isShooting,  shoot);

        

        if(shoot && anim.GetFloat(hash.shot) > 0.9)
        {

       

                 Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            ShotAudio.PlayOneShot(ShotAudio.clip);

       
             if(Physics.Raycast(camRay,  out hit , 300f, mask))
             {

             Health enemyHealth = hit.collider.GetComponent<Health>();
                if(enemyHealth != null )
                {
                    enemyHealth.TakeDamage(weaponStrenght);
                }

                     if (whiteRabbit != null)
                     whiteRabbit.position = hit.point;
                      Debug.DrawLine(transform.position, hit.point);
             }

         }
    }





}
