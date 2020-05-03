using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{
    public GameObject[] Variable;
   NavMeshAgent agent;
    public bool Infected = false;    
    

    void Start()
    {
         Variable = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Moving_Location>().Amount_Roads;
}
    /*
    agent = this.GetComponent<NavMeshAgent>();
    agent.SetDestination(Coordonnees_Du_Cube);
   */

    void Update()
    {
        
    }


    public void NewDestination(Vector3 Target) 
    {        
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(Target);
    }

    public void BecameInfected() 
    {
        Destroy(gameObject);
    }           
}





