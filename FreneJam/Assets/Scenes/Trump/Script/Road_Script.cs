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

    public GameObject Camera;
    public GameObject People;
    private Vector3 Low_Position;
    private Vector3 High_Position;

    private void Start()
    {
        Set_Position();
    }

    // 0 is neutral state
    // 1 is Sanitizer
    // 2 is Syringe
    // 3 is UV Light


    public void Set_Position() 
    {
        Low_Position = new Vector3(this.GetComponent<Transform>().position.x - 0.5f, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z - 0.5f);
        High_Position = new Vector3(this.GetComponent<Transform>().position.x + 0.5f, this.GetComponent<Transform>().position.y, this.GetComponent<Transform>().position.z + 0.5f);
    }


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

        GameObject[] Peeps = GameObject.FindGameObjectsWithTag("People");
        for (int i = 0; i < Peeps.Length; i++) 
        {            
            Transform Peep_Location = Peeps[i].GetComponent<Transform>();
            if (Road_State == 3 && Low_Position.x < Peep_Location.position.x && Peep_Location.position.x < High_Position.x && Low_Position.z < Peep_Location.position.z && Peep_Location.position.z < High_Position.z) 
            {                                
                Peeps[i].GetComponent<Agent2>().BecameInfected();
                Camera.GetComponent<Moving_Location>().People_Count -= 1;
                Debug.Log(Camera.GetComponent<Moving_Location>().People_Count);
            }

            /*
            else if (Road_State == 2 && Low_Position.x < Peep_Location.position.x && Peep_Location.position.x < High_Position.x && Low_Position.z < Peep_Location.position.z && Peep_Location.position.z < High_Position.z)
            {                
                Camera.GetComponent<Moving_Location>().Syringe_Count += 1;
                Return_Matt();
            }
            else if (Road_State == 1 && Low_Position.x < Peep_Location.position.x && Peep_Location.position.x < High_Position.x && Low_Position.z < Peep_Location.position.z && Peep_Location.position.z < High_Position.z)
            {
                Peeps[i].GetComponent<Agent2>().BecameInfected();
                Camera.GetComponent<Moving_Location>().Sanitizer_Count += 1;
                Return_Matt();
            }
            */
        }
    }

    private void Return_Matt() 
    {        
        this.gameObject.GetComponent<Renderer>().material = Normal_Matt;
        this.Road_State = 0;
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
