using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject PowerScorePref;
    public AudioSource backgroundMusic;
    public AudioSource endMusic;
    public float fuelFromEmpty;
    private GameObject Player;
   
    public GameObject endPanel;

    public float FuelLeft { get; private set; }
    public static GameMenager instance;

    public int trashList { get; private set; } = 0;

    public string MicrophoneString { get; private set; }

    public bool GameOver { get; private set; }

    void Start()
    {
        if (instance != null)
            instance = null;

        instance = this;
        instance.FuelLeft = maxFuel;
        instance.GameOver = false;
        instance.endPanel = endPanel;
        instance.endPanel.SetActive(false);
        instance.trashList = 0;
        backgroundMusic.enabled = true;
        endMusic.enabled = false;
        //AudioSource audioSource = GetComponent<AudioSource>();
        //foreach (var device in Microphone.devices)
        //    MicrophoneString = device;
        //audioSource.clip = Microphone.Start(MicrophoneString, true, 10, 44100);
        //audioSource.Play();

        if (Player == null)
            Player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        HandleTime();
        HandleFuel();
        HandleGameOverState();
    }

    private void HandleGameOverState()
    {
        if (timeLeft <= 0 || FuelLeft <= 0)
        {
            if (!GameOver)
            {
                backgroundMusic.enabled = false;
                endMusic.enabled = true;
            }
            GameOver = true;
            if (!endPanel.activeInHierarchy)
                endPanel.SetActive(true);
        }
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
        instance.trashList += 1;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowPowerScore () {
        var go = Instantiate(PowerScorePref, Player.transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = "-10";
    }

    public void EmptyTheContainer()
    {
        for (int i = 0; i < instance.trashList; i++)
        {
            AddFuel(instance.fuelFromEmpty);
        }

        instance.trashList = 0;
    }
}
