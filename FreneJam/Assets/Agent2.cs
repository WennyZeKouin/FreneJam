using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{
    public GameObject[] Variable;
   NavMeshAgent agent;
    public bool Infected = false;
    public bool Alive = true;
    public bool Arrived = false;
    public Material Infected_Matt;

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
        this.Arrived = false;
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(Target);
    }

    public void BecameInfected() 
    {
        if (Infected == false)
        {
            if (Arrived == false) 
            {
                this.GetComponent<Renderer>().material = Infected_Matt;
                Infected = true;
            }
            else
            {
                Alive = false;
                Destroy(gameObject);
            }

        }
        



        }       
}





