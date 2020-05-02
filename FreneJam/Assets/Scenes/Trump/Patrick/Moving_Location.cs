using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving_Location : MonoBehaviour
{   
    public GameObject BaracadeGameFab;
    public GameObject DealerGameFab;
    public Transform Transf;
    float CameraPosX = 0.0f;
    float CameraPosZ = 0.0f;
    private GameObject[] Amount_Roads;


    // How many units do you have at your disposal
    public int Available_Units = 10;

    // UI Stuff
    // Amount of police at your disposal
    


    // Different materials

    private float Spawning_Timer_Sanitizer;

    private float Spawning_Timer_Syringe;

    private float Spawning_Timer_UV_Light;
    
    // Start is called before the first frame update
    void Start()
    {        
        // Starts sanitizer spawner countdown
        Spawning_Timer_Sanitizer = 10;
        // Starts syringe spawner countdown
        Spawning_Timer_Syringe = 10;
        // Starts UV light spawner countdown
        Spawning_Timer_UV_Light = 10;

        // Trouve toute les route possible
        Amount_Roads = GameObject.FindGameObjectsWithTag("Road");        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI      
        


        // Countdown for spawning new locations
        Spawning_Timer_Sanitizer -= Time.deltaTime;
        Spawning_Timer_Syringe -= Time.deltaTime;
        Spawning_Timer_UV_Light -= Time.deltaTime;
        // Move the Camera around and stop if from going out of bounds
        CameraPosX = Transf.position.x;
        CameraPosZ = Transf.position.z;
        if (Input.GetKeyDown("w") && CameraPosZ > -6) 
        {
            Transf.position += new Vector3(0, 0, -1);
        }
        else if (Input.GetKeyDown("s") && CameraPosZ < 7)
        {
            Transf.position += new Vector3(0, 0, 1);
        }
        else if (Input.GetKeyDown("d") && CameraPosX > -8)
        {
            Transf.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown("a") && CameraPosX < 9)
        {
            Transf.position += new Vector3(1, 0, 0);
        }     
        // Spawn syringe, sanitizer or UV light   

        if (Spawning_Timer_Sanitizer < 0.0f) 
        {
            Spawn_Sanitizer_Full();
        }
        if (Spawning_Timer_Syringe < 0.0f) 
        {
            Spawn_Syringe_Full();
        }
        if (Spawning_Timer_UV_Light < 0.0f) 
        {
            Spawn_UV_Light_Full();
        }

        // Spawn a Roadblock or dealer
        if (Input.GetKeyDown("f"))
        {
            SpawnRoadBlock();
        }
        else if (Input.GetKeyDown("e"))
        {
            SpawnDealer();
        }

    }

    public void SpawnRoadBlock() 
    {
        if (Available_Units - 5 >= 0)
        {
            GameObject RoadBlock = Instantiate(BaracadeGameFab) as GameObject;
            RoadBlock.transform.position = new Vector3(CameraPosX, -14, CameraPosZ);
            Available_Units -= 5;
        }
        else 
        {
            Debug.Log("Not enough units available");
        }
        
    }

    public void SpawnDealer()
    {
        if (Available_Units - 7 >= 0)
        {
            GameObject RoadBlock = Instantiate(DealerGameFab) as GameObject;
            RoadBlock.transform.position = new Vector3(CameraPosX, -14.3f, CameraPosZ);
            Available_Units -= 7;
        }
        else 
        {
            Debug.Log("Not enough units available");
        }
        
    }


    // Spawn and change textures and everything else for the UV, Sanitizer and Syringe
    public void Spawn_Sanitizer_Full() 
    {
        int Sanitizer_Spawner = Random.Range(0, Amount_Roads.Length);
        Spawning_Timer_Sanitizer = Random.Range(10, 24);
        // Checking that the cube isn't already being used
        if (Amount_Roads[Sanitizer_Spawner].GetComponent<Road_Script>().Road_State == 0) 
        {
            // Changing the state of the road
            Amount_Roads[Sanitizer_Spawner].GetComponent<Road_Script>().Road_State = 1;
            // Beginning destruction timer
            Amount_Roads[Sanitizer_Spawner].GetComponent<Road_Script>().Start_Countdown(1);
            // Changing the material
            Amount_Roads[Sanitizer_Spawner].GetComponent<Road_Script>().Spawn_Sanitizer();            
        }
        
    }

    public void Spawn_Syringe_Full() 
    {
        int Syringe_Spawner = Random.Range(0, Amount_Roads.Length);
        Spawning_Timer_Syringe = Random.Range(7, 18);
        if (Amount_Roads[Syringe_Spawner].GetComponent<Road_Script>().Road_State == 0) 
        {
            //Changing the state of the road
            Amount_Roads[Syringe_Spawner].GetComponent<Road_Script>().Road_State = 2;
            // Beginning destruction timer
            Amount_Roads[Syringe_Spawner].GetComponent<Road_Script>().Start_Countdown(2);
            // Changing the material
            Amount_Roads[Syringe_Spawner].GetComponent<Road_Script>().Spawn_Syringe();
        }
    }

    public void Spawn_UV_Light_Full() 
    {
        int UV_Spawner = Random.Range(0, Amount_Roads.Length);
        Spawning_Timer_UV_Light = Random.Range(6, 10);
        if (Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Road_State == 0)
        {
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Road_State = 2;
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Start_Countdown(2);
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Spawn_UV_Light();
        }
    }

}
