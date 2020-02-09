using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLever : InteractableObjects
{

    public GameObject left_Gate;
    public GameObject right_Gate;

    public GameObject gate_Light;

    public float max_Rotation;

    [HideInInspector]public bool unlocked;

    // Update is called once per frame
    void FixedUpdate()
    {
        gate_Light.GetComponent<Light>().intensity = Mathf.PingPong(Time.time, 1.5f);
        if (unlocked)
        {
            if (time_To_Completion <= 0)
            {
                gate_Light.GetComponent<Light>().intensity = 1.5f;
                left_Gate.transform.localEulerAngles = new Vector3(0, (Mathf.Lerp(0, max_Rotation, Time.time)), 0);
                right_Gate.transform.localEulerAngles = new Vector3(0, (Mathf.Lerp(0, -max_Rotation, Time.time)), 0);
            }
        }
    }
}
