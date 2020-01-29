using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform target;
    public float rotate_Speed , Y_limit;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;//lock mouse to center and hide mouse cursor
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            //get x position of the mouse & rotate the target
            //---rotate camera horizontal
            float horizontal = Input.GetAxis("Mouse X") * rotate_Speed;
            float vertical = Input.GetAxis("Mouse Y") * rotate_Speed;

            target.Rotate(0, horizontal, 0);
            transform.Rotate(-vertical, 0, 0);

            if (transform.rotation.eulerAngles.x > Y_limit && transform.rotation.eulerAngles.x < 180)
            {
                transform.rotation = Quaternion.Euler(Y_limit,transform.eulerAngles.y, transform.eulerAngles.z);
            }
            if (transform.rotation.eulerAngles.x > 180 && transform.rotation.eulerAngles.x < 360 - Y_limit)
            {
                transform.rotation = Quaternion.Euler(360 - Y_limit, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            //float desiredYangle = this.transform.eulerAngles.y;
            //float desiredXangle = this.transform.eulerAngles.x;

            //Quaternion rotation = Quaternion.Euler(desiredXangle, 0, 0);
            //transform.position = target.position - (rotation * offset);


        }

    }
}
