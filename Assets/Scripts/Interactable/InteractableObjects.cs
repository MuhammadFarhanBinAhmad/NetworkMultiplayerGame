using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    public float starting_Time_To_Completion;
    public float time_To_Completion;
    float new_Time;

    public bool activating;

    public bool activated;

    private void Start()
    {
        time_To_Completion = starting_Time_To_Completion;
    }
}
