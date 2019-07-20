using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField]
    public float timeLeft;
    [SerializeField]
    private float maxTime;
    [SerializeField]
    public float maxFuel;
    [SerializeField]
    public TrashSpawnerScript trashSpawner;

    public float FuelLeft { get; private set; }
    public static GameMenager instance;

    public string MicrophoneString { get; private set; }

    void Start()
    {
        if (instance != null)
            instance = null;

        instance = this;
        FuelLeft = maxFuel;

        //AudioSource audioSource = GetComponent<AudioSource>();
        //foreach (var device in Microphone.devices)
        //    MicrophoneString = device;
        //audioSource.clip = Microphone.Start(MicrophoneString, true, 10, 44100);
        //audioSource.Play();
    }
    void Update()
    {
        HandleTime();
        HandleFuel();
    }

    private void AddTime(float time)
    {
        instance.timeLeft += time;
        if (instance.timeLeft > instance.maxTime)
            instance.timeLeft = instance.maxTime;
    }

    public void AddFuel(float fuel)
    {
        instance.FuelLeft = ((instance.FuelLeft + fuel) > maxFuel) ? maxFuel : instance.FuelLeft + fuel;
    }

    public void TakeFuel(float fuel)
    {
        instance.FuelLeft = ((instance.FuelLeft - fuel) >= 0) ? instance.FuelLeft - fuel : 0;
    }

    private void HandleFuel()
    {
        instance.FuelLeft = ((instance.FuelLeft - Time.deltaTime / 2) >= 0) ? instance.FuelLeft - Time.deltaTime / 2 : 0;
    }

    private void HandleTime()
    {
        if (instance.timeLeft > 0)
        {
            instance.timeLeft -= Time.deltaTime;
        }
        else if (instance.timeLeft < 0)
            instance.timeLeft = 0;
    }

    public void OnTrashDestroyed(float time, Transform trashTransform)
    {
        instance.AddTime(time);
        instance.trashSpawner.SpawnTrash(trashTransform.position);
    }
}
