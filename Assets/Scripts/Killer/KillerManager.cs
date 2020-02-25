using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerManager : MonoBehaviour
{

    public GameObject magic_Rune_Circle;
    PlayerManager current_Player;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 pivot = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(pivot, transform.forward, out hit, 3))
            {
                if (hit.collider.GetComponent<PlayerManager>() != null)
                {
                    if (hit.collider.GetComponent<PlayerManager>().is_Down)
                    {
                        Instantiate(magic_Rune_Circle, hit.collider.GetComponent<PlayerManager>().transform.position, ( Quaternion.Euler(90,0,0)));
                    }
                }
            }
        }
        
    }
}
