using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specific_Cube : MonoBehaviour
{
    private bool Pharmacie = false;
    private bool Syringe = false;
    private bool UV_Light = false;   
    
    public Material Sanitizer_Matt;
    public Material Syringe_Matt;
    public Material UV_Matt;
    public Material Normal_Matt;

    public float Time_Left;    
        
    // Update is called once per frame
    void Update()
    {        
        Debug.Log(Time_Left + " Time remaining");
        if (Pharmacie == true)
        {            
            this.gameObject.GetComponent<Renderer>().material = Sanitizer_Matt;            
            if (Time_Left < 0)
            {
                Pharmacie = false;
            }
            else 
            {
                Time_Left -= Time.deltaTime;
            }
        }
        else 
        {
            this.gameObject.GetComponent<Renderer>().material = Normal_Matt;
        }

        if (Syringe == true)
        {
            this.gameObject.GetComponent<Renderer>().material = Syringe_Matt;
            if (Time_Left <= 0)
            {
                Syringe = false;
            }            
        }
        else 
        {
            this.gameObject.GetComponent<Renderer>().material = Normal_Matt;
        }

        if (UV_Light)
        {
            this.gameObject.GetComponent<Renderer>().material = UV_Matt;
            if (Time_Left <= 0)
            {
                UV_Light = false;
            }            
        }
        else 
        {
            this.gameObject.GetComponent<Renderer>().material = Normal_Matt;
        }
    }

    public void Activate_Pharmacie() 
    {
        Pharmacie = true;
        Time_Left = 1000;
        Debug.Log("Activating Pharmacie with " + Time_Left + " left");
    }
    public void Deactivate_Pharmacie()
    {
        Pharmacie = false;
    }
    public void Activate_Sanitizer()
    {
        Time_Left = 10;
        Syringe = true;
    }
    public void Deactivate_Sanitizer()
    {
        Syringe = false;
    }
    public void Activate_UV()
    {
        Time_Left = 10;
        UV_Light = true;
    }
    public void Deactivate_UV()
    {
        UV_Light = false;
    }

}
