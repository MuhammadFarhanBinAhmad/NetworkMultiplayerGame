using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLever : InteractableObjects
{

    public GameObject left_Gate;
    public GameObject right_Gate;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left_Gate.transform.Rotate(0, 1, 0);
    }
}
