using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{

    private TextMeshProUGUI timerText;
    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timerText.text = Mathf.RoundToInt(GameMenager.instance.timeLeft).ToString();
    }
}