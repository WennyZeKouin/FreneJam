using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc : MonoBehaviour
{
    public float timerGameOver;
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        timerGameOver += Time.deltaTime;
        timerText.Text = timerGameOver.ToString();
        
    }
}
