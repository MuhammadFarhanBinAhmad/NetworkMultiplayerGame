using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : InteractableObjects
{

    private void FixedUpdate()
    {
        if (time_To_Completion <= 0)
        {
            if (!activated)
            {
                activated = true;
                GeneratorActivated();
                FindObjectOfType<GateManager>().OpenGate();
            }
        }
    }

    void GeneratorActivated()
    {
        FindObjectOfType<GateManager>().generator_Needed--;
    }
}
