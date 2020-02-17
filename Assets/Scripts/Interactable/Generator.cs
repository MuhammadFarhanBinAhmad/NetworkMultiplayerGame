using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : InteractableObjects
{

    public Light lamp_Light;

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
        if (activated)
        {
            lamp_Light.intensity = 2f;
        }
        else
        {
            lamp_Light.intensity = Mathf.PingPong(Time.time, 2f);
        }
    }

    void GeneratorActivated()
    {
        FindObjectOfType<GateManager>().generator_Needed--;
    }
}
