using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class Moving_Location : MonoBehaviour
{   
    public GameObject BaracadeGameFab;
    public GameObject DealerGameFab;
    public GameObject People;
    public Transform Transf;
    float CameraPosX = 0.0f;
    float CameraPosZ = 0.0f;
    public GameObject[] Amount_Roads;

    // A rajouter a l'UI et faire en sorte que des que ca deviens 0 on a un game overscreen.
    public int People_Count = 20;
    // Compteur avant que de nouvelle personne spawn
    float People_Counter = 30;

    // A rajouter a l'UI et si jamais il y a 10 bouteille de sanitizer et 5 eguille alors le joueur perdra 50 personne

    // public int Sanitizer_Count = 0;

    // public int Syringe_Count = 0;





    // How many units do you have at your disposal
    public int Available_Units = 10;
    float Reinforcement_Counter = 15;
    // UI Stuff
    // Amount of police at your disposal
    


    // Different materials

    private float Spawning_Timer_Sanitizer;

    private float Spawning_Timer_Syringe;

    private float Spawning_Timer_UV_Light;

    static float timerGameOver;
    
    // Start is called before the first frame update
    void Start()
    {        
        // Starts sanitizer spawner countdown
        //Spawning_Timer_Sanitizer = 10;
        // Starts syringe spawner countdown
        //Spawning_Timer_Syringe = 10;
        // Starts UV light spawner countdown
        Spawning_Timer_UV_Light = 5;

        // Trouve toute les route possible
        Amount_Roads = GameObject.FindGameObjectsWithTag("Road");
        //Spawner 10 personne pour test  
        Spawn_Multi_People(10);
        


    }

    // Update is called once per frame
    void Update()
    {
        // Verifie si les americain ont ramasser les objects
        /*
        if (Syringe_Count == 5 && Sanitizer_Count == 10) 
        {
            People_Count -= 50;
        }
        */
        timerGameOver += Time.deltaTime;
        GuiText.Text=timerGameOver.ToString();
        // Verifie si le jeu est fini
        if (People_Count <= 0) 
        {
            Debug.Log("Game Over");
            Application.Quit();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

       

        //Update Units available
        Reinforcement_Counter -= Time.deltaTime;
        if (Reinforcement_Counter < 0)         
        {           
            Available_Units += Random.Range(1, 3);
            Reinforcement_Counter = 15;
        }

        // Spawn new people
        People_Counter -= Time.deltaTime;
        if (People_Counter < 0) 
        {
            Spawn_Multi_People(Random.Range(10, 20));
            People_Counter = 15;
        }

        // Update the UI      
        

        // Countdown for spawning new locations

        //Spawning_Timer_Sanitizer -= Time.deltaTime;

        // Spawning_Timer_Syringe -= Time.deltaTime;

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
        /*
        if (Spawning_Timer_Sanitizer < 0.0f && Sanitizer_Count < 10) 
        {
            Spawn_Sanitizer_Full();            
        }
        if (Spawning_Timer_Syringe < 0.0f && Syringe_Count < 5) 
           
        {
            Spawn_Syringe_Full();
        }
        */
        if (Spawning_Timer_UV_Light < 0.0f && People_Count > 0) 
        {
            Spawn_UV_Light_Full();
        }

        // Spawn a Roadblock or dealer
        if (Input.GetKeyDown("f"))
        {
            SpawnRoadBlock();            
        }
        /*
        else if (Input.GetKeyDown("e"))
        {
            SpawnDealer();
        }
        */

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
        }
        
    }

    public void SpawnDealer()
    {
        if (Available_Units - 7 >= 0)
        {
            GameObject RoadBlock = Instantiate(DealerGameFab) as GameObject;
            RoadBlock.transform.position = new Vector3(CameraPosX, -14.3f, CameraPosZ);
            Available_Units -= 7;
            GameObject[] Peeps = GameObject.FindGameObjectsWithTag("People");
            for (int i = 0; i < Peeps.Length; i++)
            {
                Peeps[i].GetComponent<Agent2>().NewDestination(RoadBlock.transform.position);             
            }
        }
        else 
        {            
        }
        
    }


    // Spawn and change textures and everything else for the UV, Sanitizer and Syringe


    /*
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

            if (GameObject.Find("Dealer(Clone)") == null) 
            {
                GameObject[] Peeps = GameObject.FindGameObjectsWithTag("People");
                for (int i = 0; i < Peeps.Length; i++)
                {
                    int Chance = Random.Range(0, 2);
                    if (Chance == 1)
                    {
                        Peeps[i].GetComponent<Agent2>().NewDestination(Amount_Roads[Sanitizer_Spawner].GetComponent<Road_Script>().GetLocation_Cube());
                    }

                }
            }
            
        }
        
    }
    */
    /*
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

            if (GameObject.Find("Dealer(Clone)") == null)
            {
                GameObject[] Peeps = GameObject.FindGameObjectsWithTag("People");
                for (int i = 0; i < Peeps.Length; i++)
                {
                    int Chance = Random.Range(0, 2);
                    if (Chance == 1)
                    {
                        Peeps[i].GetComponent<Agent2>().NewDestination(Amount_Roads[Syringe_Spawner].GetComponent<Road_Script>().GetLocation_Cube());
                    }

                }
            }
        }
    }
    */
    public void Spawn_UV_Light_Full() 
    {
        int UV_Spawner = Random.Range(0, Amount_Roads.Length);
        Spawning_Timer_UV_Light = Random.Range(6, 10);
        if (Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Road_State == 0)
        {
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Road_State = 3;
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Start_Countdown(2);
            Amount_Roads[UV_Spawner].GetComponent<Road_Script>().Spawn_UV_Light();

            if (GameObject.Find("Dealer(Clone)") == null)
            {

                GameObject[] Peeps = GameObject.FindGameObjectsWithTag("People");
                for (int i = 0; i < Peeps.Length; i++)
                {                    
                        Peeps[i].GetComponent<Agent2>().NewDestination(Amount_Roads[UV_Spawner].GetComponent<Road_Script>().GetLocation_Cube());
                    

                }
            }
        }
    }


    // Spawn all the people

    public void Spawn_People()
    {
        GameObject People_Spawn = Instantiate(People) as GameObject;
        int Rand_Valve = Random.Range(0,9);
        if (Rand_Valve == 0) 
        {
            People_Spawn.transform.position = new Vector3(9f, -14.166f, -6f);
        }
        else if (Rand_Valve == 1)
        {
            People_Spawn.transform.position = new Vector3(-7f, -14.166f, -6f);
        }
        else if (Rand_Valve == 2)
        {
            People_Spawn.transform.position = new Vector3(-8f, -14.166f, 7f);
        }
        else if (Rand_Valve == 3)
        {
            People_Spawn.transform.position = new Vector3(9f, -14.166f, 7f);
        }
        else if (Rand_Valve == 4)
        {
            People_Spawn.transform.position = new Vector3(9f, -14.166f, 7f);
        }
        else if (Rand_Valve == 5)
        {
            People_Spawn.transform.position = new Vector3(9f, -14.166f, -3f);
        }
        else if (Rand_Valve == 6)
        {
            People_Spawn.transform.position = new Vector3(6f, -14.166f, -6f);
        }
        else if (Rand_Valve == 7)
        {
            People_Spawn.transform.position = new Vector3(0f, -14.166f, -6f);
        }
        else if (Rand_Valve == 8)
        {
            People_Spawn.transform.position = new Vector3(-5f, -14.166f, -6f);
        }
        
    }

    public void Spawn_Multi_People(int Amount) 
    {
        while (Amount > 0) 
        {
            Spawn_People();
            Amount -= 1;
        }
    }
}
