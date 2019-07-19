using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenager : MonoBehaviour
{
    [SerializeField]
    public float time = 10;

    public static GameMenager instance;

    void Start()
    {
        if (instance != null)
            instance = null;

        instance = new GameMenager();
    }
    void Update()
    {
        time -= Time.deltaTime;
    }
}
