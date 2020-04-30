using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
  

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cgreen")
        {
            Destroy(gameObject);

        }

       
    }
}
