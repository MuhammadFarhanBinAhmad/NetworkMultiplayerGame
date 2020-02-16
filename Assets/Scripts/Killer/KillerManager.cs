using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerManager : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 pivot = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);


        if (Physics.Raycast(pivot, transform.forward, out hit, 3))
        {
            if (hit.collider.GetComponent<PlayerManager>() != null)
            {
                if (hit.collider.GetComponent<PlayerManager>().is_Down)
                {
                    print("hit");
                }
            }
        }
    }
}
