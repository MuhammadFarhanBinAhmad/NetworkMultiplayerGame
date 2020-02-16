using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerWeapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            if (other.GetComponent<PlayerManager>().is_Hurt)
            {
                other.GetComponent<PlayerManager>().is_Down = true;
            }
            else
            {
                other.GetComponent<PlayerManager>().is_Hurt = true;
            }
        }
    }
}
