using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{
    public GameObject[] Variable;
   NavMeshAgent agent;

    void Start()
    {
         Variable = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Moving_Location>().Amount_Roads;
}

    
   
    void Update()
    {

        for (int i = 0; i < Variable.Length; i++) 
        {
            if (Variable[i].GetComponent<Road_Script>().Road_State == 1)
            {
               

                Vector3 Coordonnees_Du_Cube = Variable[i].GetComponent<Road_Script>().GetLocation_Cube();
                

                agent = this.GetComponent<NavMeshAgent>();
                agent.SetDestination(Coordonnees_Du_Cube);
            }
        }
     }

    
   

   
}





