using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target , pivot;
    public Vector3 offset;//store data on how far the camera is from the target

    public bool useOffsetValue;

    public float rotate_Speed , Y_limit;

    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValue)
        {
            offset = target.position - transform.position;
        }

        Vector3 vec = new Vector3(target.position.x, target.position.y + 1, target.position.z);

        pivot.transform.position = vec;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;//lock mouse to center and hide mouse cursor
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (target != null)
        {
            //get x position of the mouse & rotate the target
            //---rotate camera horizontal
            float horizontal = Input.GetAxis("Mouse X") * rotate_Speed;
            if (!GetComponentInParent<PlayerManager>().fixing)
            {
                target.Rotate(0, horizontal, 0);
            }
            //get y pos of mouse & rotate the pivot
            //---move camera vertical
            float vertical = Input.GetAxis("Mouse Y") * rotate_Speed;
            pivot.Rotate(vertical, 0, 0);

            //clamp camera rotation

            if (pivot.rotation.eulerAngles.x > Y_limit && pivot.rotation.eulerAngles.x < 180)
            {
                pivot.rotation = Quaternion.Euler(Y_limit, 0, 0);
            }
            if (pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360 - Y_limit)
            {
                pivot.rotation = Quaternion.Euler(360 - Y_limit, 0, 0);
            }

            //move camera base on current rotation of the target & the original offset
            float desiredYangle = target.eulerAngles.y;
            float desiredXangle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYangle, 0);

            transform.position = target.position - (rotation * offset);

            //stop camera from going under player
            if (transform.position.y < target.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z);
            }
            transform.LookAt(pivot);//camera constantly look at target
        }

    }
}
