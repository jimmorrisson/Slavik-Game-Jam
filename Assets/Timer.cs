using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{

    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = GameMenager.instance.timeLeft.ToString();
        
    }
}