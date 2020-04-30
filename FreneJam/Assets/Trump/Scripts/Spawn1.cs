using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject Spawnee;

    

    void Start()
    {
        Invoke("SpawnAgent", 2);
    }


    void SpawnAgent()
    {
        Instantiate(Spawnee, spawnPos.position, spawnPos.rotation);
        Invoke("SpawnAgent",1 ); // Random.Range(2,5)
    }


  
          
    //void Update()
   // {
        //if (Input.GetKeyDown("space"))
        //{
        //    Instantiate(Spawnee, spawnPos.position, spawnPos.rotation);

        //}


  //  }
}
