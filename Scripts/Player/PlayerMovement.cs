using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float SpeedDumbTime = 0.1f;
    public float speed = 6f;
    public AudioClip shoutAudio;

    private Vector3 movement;
    private Animator anim;
    private int groundMask;
    private Rigidbody rb;
    private float  CamRayLenght = 100f;
    private HaszIDs hash;

    private Health playerHealth;
    private bool PlayerAnimIsDead;
    
     void Awake()
    {
        groundMask = LayerMask.GetMask(Layers.ground);

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HaszIDs>();

        anim.SetLayerWeight(1, 1f);
        playerHealth = GetComponent<Health>();
        PlayerAnimIsDead = true;
    }

    void FixedUpdate()
    {
        if (!playerHealth.isDead)
        {

        
        float h = Input.GetAxisRaw(Inputs.horizontal);
        float v = Input.GetAxisRaw(Inputs.vertical);
        bool shouting = Input.GetButtonDown(Inputs.shouting);

        MovementMenager(h, v);
        Turning();
        ShoutManagement(shouting);
        }
        else
        {
            DeathAnimation();
        }

    }

    private void DeathAnimation()
    {
       if(PlayerAnimIsDead)
        {
            anim.SetTrigger(hash.isDead);
            PlayerAnimIsDead = false;
        }
     

    }


    void MovementMenager(float horizontal, float vertical)
    {
        if(horizontal != 0f || vertical != 0f)
        {
            anim.SetFloat(hash.speed, 5.5f, SpeedDumbTime, Time.deltaTime);
        }
        else
            anim.SetFloat(hash.speed,0f);

    }

    void Turning()
    {
        Ray CamRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit groundHit;

        if(Physics.Raycast(CamRay, out groundHit, CamRayLenght, groundMask))
        {
            Vector3 playerToMouse = groundHit.point - transform.position;

            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(newRotation);

        }
    }

    void ShoutManagement(bool shout)
    {
        
            anim.SetBool(hash.isShouting, shout);
            ShoutAudio(shout);
        
    }

    void ShoutAudio(bool shout)
    {
        if (shoutAudio != null)
            if (shout)
                AudioSource.PlayClipAtPoint(shoutAudio, transform.position);
    }




}