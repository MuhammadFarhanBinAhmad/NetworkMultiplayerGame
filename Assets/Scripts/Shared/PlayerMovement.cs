using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public enum CurrentCharacter
    {
        Survivor,
        Killer
    }
    public CurrentCharacter the_Current_Character;
    //---Player Stats
    //Player Movement and Physic
    [Header("Player Stats")]
    public float starting_Movement_Speed;
    public float move_Speed;

    Animator player_Anim;

    //Player Movement
    CharacterController theCC;
    Vector3 moveDirection;


    void Start()
    {
        theCC = GetComponent<CharacterController>();
        player_Anim = GetComponent<Animator>();
        //move_Speed = starting_Movement_Speed;

        //for killer
        if (player_Anim.layerCount == 2)
        {
            player_Anim.SetLayerWeight(1, .5f);
        }
    }

    void FixedUpdate()
    {
        PlayerMovementControl();
    }

    void PlayerMovementControl()
    {
        //PlayerMovement
        float Ystore = moveDirection.y;//store whatever y direction player currently in

        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float crouch = Input.GetAxis("Crouch");

        moveDirection = (transform.forward * vertical * move_Speed) + (transform.right * horizontal * move_Speed);//move in correlation with the directin of the camera & enable player to strafe
        moveDirection = moveDirection.normalized * move_Speed;

        theCC.Move(moveDirection * Time.deltaTime);//enable player to move in the world

        player_Anim.SetFloat("Running", vertical);
        player_Anim.SetFloat("Strafing", horizontal);


        if (!theCC.isGrounded)
        {
            float gravity = 9.81f;

            theCC.Move(-transform.up * gravity * Time.deltaTime);
        }


        switch (the_Current_Character)
        {
            case CurrentCharacter.Survivor:
                if (GetComponent<PlayerManager>().is_Hurt)
                {
                    player_Anim.SetBool("Injured", true);
                    move_Speed = starting_Movement_Speed / 2;
                    if (GetComponent<PlayerManager>().is_Down)
                    {
                        player_Anim.SetBool("Down", true);
                        move_Speed = starting_Movement_Speed / 5;
                    }
                }
                else
                {
                    player_Anim.SetBool("Injured", false);
                    player_Anim.SetBool("Down", false);
                    move_Speed = starting_Movement_Speed;
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    player_Anim.SetFloat("Crouch", crouch);
                    GetComponent<CharacterController>().height = 1;
                    GetComponent<CharacterController>().center = new Vector3(0, .45f, 0);
                    move_Speed = starting_Movement_Speed / 2;

                }
                else
                {
                    player_Anim.SetFloat("Crouch", crouch);
                    GetComponent<CharacterController>().height = 1.7f;
                    GetComponent<CharacterController>().center = new Vector3(0, .85f, 0);
                }

                break;
            case CurrentCharacter.Killer:

                AnimatorStateInfo current_Base_State;
                AnimatorStateInfo attack_State;


                current_Base_State = player_Anim.GetCurrentAnimatorStateInfo(0);

                if (player_Anim.layerCount == 2)
                {
                    attack_State = player_Anim.GetCurrentAnimatorStateInfo(1);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    player_Anim.SetBool("Attacking", true);
                }
                else
                {
                    player_Anim.SetBool("Attacking", false);
                }
                break;
        }
    }
}

