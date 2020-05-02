using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Script : MonoBehaviour
{
    public Material Sanitizer_Matt;
    public Material Syringe_Matt;
    public Material UV_Light_Matt;
    public Material Normal_Matt;
    private float CounterLife = 0.0f;

    public int Road_State = 0;
    // 0 is neutral state
    // 1 is Sanitizer
    // 2 is Syringe
    // 3 is UV Light



    public void Start_Countdown(int Item) 
    {
        if (Item == 1)
        {
            CounterLife = 6;
        }
        else if (Item == 2) 
        {
            CounterLife = 5;
        }
        else if (Item == 3)
        {
            CounterLife = 3;
        }
    }

    private void Update()
    {
        CounterLife -= Time.deltaTime;        
        if (CounterLife <= 0.0f) 
        {
            Return_Matt();
        }
    }

    private void Return_Matt() 
    {        
        this.gameObject.GetComponent<Renderer>().material = Normal_Matt;
    }


    public void Spawn_Sanitizer() 
    {
        Debug.Log("Spawn Sanitizer");
        this.gameObject.GetComponent<Renderer>().material = Sanitizer_Matt;
    }
    public void Spawn_Syringe() 
    {
        Debug.Log("Spawn Syringe");
        this.gameObject.GetComponent<Renderer>().material = Syringe_Matt;
    }

    public void Spawn_UV_Light()
    {
        Debug.Log("Spawn UV Light");
        this.gameObject.GetComponent<Renderer>().material = UV_Light_Matt;
    }

    public Vector3 GetLocation_Cube()
    {
        return this.gameObject.GetComponent<Transform>().position;
    }
}
