using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField]
    public float timeLeft =  10;
    [SerializeField]
    public float FuelLeft = 10;

    public static GameMenager instance;

    public string MicrophoneString { get; private set; }

    void Start()
    {
        if (instance != null)
            instance = null;

        instance = new GameMenager();
        AudioSource audioSource = GetComponent<AudioSource>();
        foreach (var device in Microphone.devices)
            MicrophoneString = device;
        audioSource.clip = Microphone.Start(MicrophoneString, true, 10, 44100);
        audioSource.Play();
    }
    void Update()
    {
        if (instance.timeLeft > 0)
        {
            instance.timeLeft -= Time.deltaTime;
        }
        else if (instance.timeLeft < 0)
            instance.timeLeft = 0;

        if (instance.timeLeft <= 0)
            Debug.Log("Game over");
    }
}
