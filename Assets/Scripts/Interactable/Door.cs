using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator the_Anim;

    private void Start()
    {
        the_Anim = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        the_Anim.SetBool("Open", true);
        StartCoroutine("CloseDoor");
    }
    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5);
        the_Anim.SetBool("Open", false);
    }
}
