using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Location : MonoBehaviour
{
    public GameObject BaracadeGameFab;
    public GameObject DealerGameFab;
    public Transform Transf;
    float CameraPosX = 0.0f;
    float CameraPosZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {        
        
    }

    // Update is called once per frame
    void Update()
    {
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
        GameObject RoadBlock = Instantiate(BaracadeGameFab) as GameObject;
        RoadBlock.transform.position = new Vector3(CameraPosX, -14, CameraPosZ);
    }

    public void SpawnDealer()
    {
        GameObject RoadBlock = Instantiate(DealerGameFab) as GameObject;
        RoadBlock.transform.position = new Vector3(CameraPosX, -13, CameraPosZ);
    }
}
