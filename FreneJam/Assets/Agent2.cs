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
            if (Variable[i].GetComponent<Road_Script>().Road_State != 0)
            {
               

                Vector3 Coordonnees_Du_Cube = Variable[i].GetComponent<Road_Script>().GetLocation_Cube();

                Debug.Log("On a les coordonnées");

                agent = this.GetComponent<NavMeshAgent>();
                agent.SetDestination(Coordonnees_Du_Cube);
            }
        }
     }

    
   

   
}





