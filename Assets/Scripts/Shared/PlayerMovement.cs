using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    //---Player Stats
    //Player Movement and Physic
    [Header("Player Stats")]
    public float move_Speed;
    float total_Player_Health;
    float gravity_Scale = 0.2f;

    public Image health_Bar;

    //Player Movement
    public bool currently_Moving;
    CharacterController theCC;
    Vector3 moveDirection;


    void Start()
    {
        theCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        //PlayerMovement
        float Ystore = moveDirection.y;//store whatever y direction player currently in
        moveDirection = (transform.forward * Input.GetAxis("Vertical") * move_Speed) + (transform.right * Input.GetAxis("Horizontal") * move_Speed);//move in correlation with the directin of the camera & enable player to strafe
        moveDirection = moveDirection.normalized * move_Speed;
        moveDirection.y = Ystore;

        /*if (theCC.isGrounded)
        {
            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jump_Force;
            }
        }*/

        //moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity_Scale);//apply gravity
        theCC.Move(moveDirection * Time.deltaTime);//enable player to move in the world
    }
}
