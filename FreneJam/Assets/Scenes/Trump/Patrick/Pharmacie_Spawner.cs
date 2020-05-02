using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pharmacie_Spawner : MonoBehaviour
{
    private GameObject[] RoadCubes;
    int Amount_Roads;
    // public Material Sanitizer;
    // public Material Syringe;
    // Start is called before the first frame update
    void Start()
    {
        // Find all the different Roads
        RoadCubes = GameObject.FindGameObjectsWithTag("Road");
        Amount_Roads = RoadCubes.Length;
        // Which spawn will be activated:        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y")) 
        {
            Choose_Spawn_Soap();
        }
    }

    private void Choose_Spawn_Soap() 
    {
        
        int spawner = Random.Range(0, Amount_Roads);
        //RoadCubes[spawner].GetComponent<Renderer>().material = Sanitizer;
        RoadCubes[spawner].GetComponent<Specific_Cube>().Activate_Pharmacie();
        RoadCubes[spawner].GetComponent<Specific_Cube>().Time_Left = 10;
    }
}
