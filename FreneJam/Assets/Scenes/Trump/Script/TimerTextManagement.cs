using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerTextManagement : MonoBehaviour
{
    public float timerGameOver;
    public TextMeshProUGUI timerText;

    void Start()
    {
        timerGameOver =0f;    
    }
    // Update is called once per frame
    void Update()
    {
        timerGameOver += Time.deltaTime;
        timerText.GetComponent<TextMeshProUGUI>().text = timerGameOver.ToString();
        
    }
}
