using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() !=null)
        {
            other.GetComponent<PlayerManager>().escape = true;
            print("hit");
        }
    }
}
