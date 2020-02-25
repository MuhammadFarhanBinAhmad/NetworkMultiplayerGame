using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCircle : MonoBehaviour
{
    public PlayerManager current_Trap_Survivor_Manager;

    public float starting_Time;
    public float time_Left;

    private void Start()
    {
        time_Left = starting_Time;
    }

    private void FixedUpdate()
    {
        if (current_Trap_Survivor_Manager !=null && time_Left>= 0)
        {
            time_Left -= Time.deltaTime;
        }
        if (time_Left <= 0)
        {
            Destroy(current_Trap_Survivor_Manager.gameObject);
            Destroy(gameObject);
        }
        if (!current_Trap_Survivor_Manager.is_Dying)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (current_Trap_Survivor_Manager == null)
        {
            if (other.GetComponent<PlayerManager>() !=null && other.GetComponent<PlayerManager>().is_Down)
            {
                current_Trap_Survivor_Manager = other.GetComponent<PlayerManager>();
                current_Trap_Survivor_Manager.is_Dying = true;
                current_Trap_Survivor_Manager.the_Anim.SetBool("Dying", true);
                current_Trap_Survivor_Manager.bar_Holder.SetActive(true);
                current_Trap_Survivor_Manager.fill_Bar.fillAmount = time_Left / starting_Time;
                other.GetComponent<PlayerMovement>().move_Speed = 0;
            }
        }
    }
}
