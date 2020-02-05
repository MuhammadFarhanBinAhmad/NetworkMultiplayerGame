using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{

    public int generator_Needed;

    public List<Gate> gates = new List<Gate>();

    // Start is called before the first frame update
    void Start()
    {
        gates.AddRange(GameObject.FindObjectsOfType<Gate>());//placing all enemy in list
    }

    public void OpenGate()
    {
        if (generator_Needed == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                int no = Random.Range(0, gates.Count);
                gates[no].unlocked = true;
                gates[no].gate_Light.SetActive(true);
                gates.Remove(gates[no]);
            }
        }
    }
}
