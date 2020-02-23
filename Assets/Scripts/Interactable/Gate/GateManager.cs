using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{

    public List<Transform> generator_Spawning_Point = new List<Transform>();
    public GameObject generator;
    public int generator_Needed;

    public List<GateLever> gates = new List<GateLever>();

    private void Awake()
    {
        for(int i = 0; i <= 3; i++)
        {
            int number = Random.Range(0, generator_Spawning_Point.Count - 1);
            Instantiate(generator, generator_Spawning_Point[number].position, transform.rotation);
            generator_Spawning_Point.Remove(generator_Spawning_Point[number]);
        }
    }
    void Start()
    {
        gates.AddRange(GameObject.FindObjectsOfType<GateLever>());//placing all enemy in list
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
