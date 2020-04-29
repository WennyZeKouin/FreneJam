using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstqcle : MonoBehaviour
{
    bool open = false;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open)
                this.transform.Translate(0, 3, 0);
            else
                this.transform.Translate(0, -3, 0);

            open = !open;
        }
    }
}
