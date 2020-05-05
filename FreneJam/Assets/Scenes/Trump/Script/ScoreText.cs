using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public static int scoreValue;
    Text score;

    // Start is called before the first frame update
    void Start()
    {

        scoreValue = 20;
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Stupid american left: " + scoreValue;
    }
}
