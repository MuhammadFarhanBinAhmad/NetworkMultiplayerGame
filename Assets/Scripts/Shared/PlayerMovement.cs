using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    //---Player Stats
    //Player Movement and Physic
    [Header("Player Stats")]
    public float starting_Movement_Speed;
    public float move_Speed;

    public Image health_Bar;

    Animator player_Anim;

    //Player Movement
    public bool currently_Moving;
    CharacterController theCC;
    Vector3 moveDirection;


    void Start()
    {
        theCC = GetComponent<CharacterController>();
        player_Anim = GetComponent<Animator>();
        move_Speed = starting_Movement_Speed;
    }

    void FixedUpdate()
    {
        //PlayerMovement
        float Ystore = moveDirection.y;//store whatever y direction player currently in

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");

        moveDirection = (transform.forward * vertical * move_Speed) + (transform.right * horizontal * move_Speed);//move in correlation with the directin of the camera & enable player to strafe
        moveDirection = moveDirection.normalized * move_Speed;

        theCC.Move(moveDirection * Time.deltaTime);//enable player to move in the world

        player_Anim.SetFloat("Running", vertical);
        player_Anim.SetFloat("Strafing", horizontal);


    }
}
