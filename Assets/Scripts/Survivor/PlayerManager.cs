using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public bool is_Hurt;
    bool test;

    PlayerMovement the_Player_Movement;

    private void Start()
    {
        the_Player_Movement = GetComponent<PlayerMovement>();
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
                   }
                }
                else
                {
                    hit.collider.GetComponent<InteractableObjects>().activating = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KillerWeapon>() !=null)
        {
            if (!is_Hurt)
            {
                the_Player_Movement.move_Speed /= 2;
                is_Hurt = true;
            }
            else
            {
                the_Player_Movement.move_Speed = 0;
            }
        }
        if (other.name == "Health")
        {
            the_Player_Movement.move_Speed = the_Player_Movement.starting_Movement_Speed;
        }
    }


}
