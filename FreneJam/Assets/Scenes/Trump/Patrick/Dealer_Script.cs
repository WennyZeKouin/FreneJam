﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer_Script : MonoBehaviour
{
    public GameObject Dealer;
    float Time_Left;
    // Start is called before the first frame update
    void Start()
    {
        Time_Left = 25;
    }

    // Update is called once per frame
    void Update()
    {
        Time_Left -= Time.deltaTime;

        if (Time_Left <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
