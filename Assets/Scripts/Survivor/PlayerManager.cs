using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public enum InteractingObject
    {
        Generator,
        HealPlayer,
        OpenDoor
    }

    public InteractingObject interacting_Object;

     public bool is_Hurt;
     public bool is_Down;
    [HideInInspector] public bool fixing;
    [HideInInspector] public bool escape;
    // player components
    PlayerMovement the_Player_Movement;
    Animator the_Anim;
    public GameObject bar_Holder;
    public Image fill_Bar;
    //Interactable Objects
    public InteractableObjects current_Interactable_Object;
    public PlayerManager other_Player;
    public Door current_Door;

    public GameObject test;

    public float starting_Revive_Time;
    public float revive_Time;

    private void Start()
    {
        the_Anim = GetComponent<Animator>();
        the_Player_Movement = GetComponent<PlayerMovement>();
        revive_Time = starting_Revive_Time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (test != null)
        {
            print(Vector3.Distance(test.transform.position,transform.position));
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 foward = transform.TransformDirection(Vector3.forward);
            Vector3 pivot = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
            RaycastHit hit;
            if (Physics.Raycast(pivot, foward, out hit, 3))
            {

                if (hit.collider.GetComponent<InteractableObjects>() != null)
                {
                    current_Interactable_Object = hit.collider.GetComponent<InteractableObjects>();
                    interacting_Object = InteractingObject.Generator;
                }
                else
                {
                    current_Interactable_Object = null;
                }
                if (hit.collider.GetComponent<PlayerManager>() != null)
                {
                    other_Player = hit.collider.GetComponent<PlayerManager>();
                    interacting_Object = InteractingObject.HealPlayer;
                }
                else
                {
                    other_Player = null;
                }
                if (hit.collider.gameObject.GetComponent<Door>() != null)
                {
                    print("hit");
                    current_Door = hit.collider.GetComponent<Door>();
                    interacting_Object = InteractingObject.OpenDoor;
                }
                else
                {
                    current_Door = null;
                }
                InteractingCurrentObject();
            }
            if (revive_Time <= 0)
            {
                HealPlayer();
            }
        }
        void InteractingCurrentObject()
        {
            switch (interacting_Object)
            {
                case InteractingObject.OpenDoor:
                    {
                        current_Door.OpenDoor();
                    }
                    break;
                case InteractingObject.Generator:
                    {
                        if (current_Interactable_Object.activated == false)
                        {
                            bar_Holder.SetActive(true);
                            current_Interactable_Object.time_To_Completion--;
                            fill_Bar.fillAmount = current_Interactable_Object.time_To_Completion / current_Interactable_Object.starting_Time_To_Completion;
                            current_Interactable_Object.activating = true;
                            GetComponent<Animator>().SetBool("Fixing", true);
                            fixing = true;
                            the_Player_Movement.move_Speed = 0;
                        }
                        else if (current_Interactable_Object.activated == true)
                        {
                            bar_Holder.SetActive(false);
                            the_Anim.SetBool("Fixing", false);
                            fixing = true;
                        }
                        else
                        {
                            current_Interactable_Object.activating = false;
                            fixing = false;
                            the_Anim.SetBool("Fixing", false);
                            if (!is_Hurt)
                            {
                                the_Player_Movement.move_Speed = the_Player_Movement.starting_Movement_Speed;
                            }
                            else
                            {
                                the_Player_Movement.move_Speed = the_Player_Movement.starting_Movement_Speed / 2;
                            }
                        }
                    }
                    break;
                case InteractingObject.HealPlayer:
                    if (other_Player != null)
                    {
                        if (other_Player.is_Down == true)
                        {
                            {
                                if (other_Player.revive_Time >= 0)
                                {
                                    other_Player.revive_Time--;
                                    the_Anim.SetBool("Fixing", true);
                                }
                            }
                        }
                    }
                    break;
                
            }
        }
        void HealPlayer()
        {
            revive_Time = starting_Revive_Time;
            is_Down = false;
            is_Hurt = false;
            the_Anim.SetBool("Injured", false);
            the_Anim.SetBool("Down", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "test")
        {
            test = other.gameObject;
        }
    }
}
