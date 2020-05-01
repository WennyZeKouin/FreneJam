using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pharmacie_Spawner : MonoBehaviour
{
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    public GameObject Spawn6;
    public GameObject Spawn7;

    public Material Sanitizer;
    public Material Syringe;
    // Start is called before the first frame update
    void Start()
    {
        // Which spawn will be activated:        
        Choose_Spawn_Soap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Choose_Spawn_Soap() 
    {
        int spawner = Random.Range(0, 7);
        if (spawner == 0)
        {
            Spawn1.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 1)
        {
            Spawn2.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 2)
        {
            Spawn3.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 3)
        {
            Spawn4.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 4)
        {
            Spawn5.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 5)
        {
            Spawn6.GetComponent<Renderer>().material = Sanitizer;
        }
        else if (spawner == 6)
        {
            Spawn7.GetComponent<Renderer>().material = Sanitizer;
        }
    }
}
