using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [HideInInspector] public bool is_Hurt;
    [HideInInspector] public bool is_Down;
    [HideInInspector] public bool fixing;

    public float starting_Revive_Time;
    public float revive_Time;

    PlayerMovement the_Player_Movement;
    private void Start()
    {
        the_Player_Movement = GetComponent<PlayerMovement>();
        revive_Time=starting_Revive_Time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 foward = transform.TransformDirection(Vector3.forward);
        Vector3 pivot = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
        RaycastHit hit;

        if (Physics.Raycast(pivot, foward, out hit,3))
        {
            if (hit.collider.GetComponent<InteractableObjects>() != null)
            {
                if (Input.GetMouseButton(0))
                {
                   if (hit.collider.GetComponent<InteractableObjects>().activated == false)
                   {
                        hit.collider.GetComponent<InteractableObjects>().time_To_Completion--;
                        hit.collider.GetComponent<InteractableObjects>().activating = true;
                        GetComponent<Animator>().SetBool("Fixing", true);
                        fixing = true;
                        GetComponent<PlayerMovement>().move_Speed = 0;
                   }
                   else if (hit.collider.GetComponent<InteractableObjects>().activated == true)
                   {
                        GetComponent<Animator>().SetBool("Fixing", false);
                        fixing = true;
                    }
                }
                else
                {
                    hit.collider.GetComponent<InteractableObjects>().activating = false;
                    fixing = false;
                    GetComponent<Animator>().SetBool("Fixing", false);
                    if (!is_Hurt)
                    {
                        GetComponent<PlayerMovement>().move_Speed = GetComponent<PlayerMovement>().starting_Movement_Speed;
                    }
                    else
                    {
                        GetComponent<PlayerMovement>().move_Speed = GetComponent<PlayerMovement>().starting_Movement_Speed/2;
                    }
                }
            }
            if (hit.collider.GetComponent<PlayerManager>() != null)
            {
                print(hit.collider.name);
                if (Input.GetMouseButton(0))
                {
                    if (hit.collider.GetComponent<PlayerManager>().is_Down == true)
                    {
                        {
                            if (hit.collider.GetComponent<PlayerManager>().revive_Time >= 0)
                            {
                                hit.collider.GetComponent<PlayerManager>().revive_Time--;
                                GetComponent<Animator>().SetBool("Fixing", true);
                            }
                        }
                    }
                }
            }
        }
        if (revive_Time <=0)
        {
            HealPlayer();
        }
    }

    void HealPlayer()
    {
        revive_Time = starting_Revive_Time;
        is_Down = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KillerWeapon")
        {
            if (!is_Hurt)
            {
                is_Hurt = true;
            }
            else if (is_Hurt && !is_Down)
            {
                is_Down = true;
            }
        }
        if (other.name == "Health")
        {
            the_Player_Movement.move_Speed = the_Player_Movement.starting_Movement_Speed;
        }
    }
}
