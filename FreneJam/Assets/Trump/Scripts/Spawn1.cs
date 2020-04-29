using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject Spawnee;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(Spawnee, spawnPos.position, spawnPos.rotation);

        }


    }
}
