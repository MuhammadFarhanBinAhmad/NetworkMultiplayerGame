using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : InteractableObjects
{

    public bool unlocked;

    public GameObject gate_Light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (time_To_Completion <= 0)
        {

        }
    }
}
