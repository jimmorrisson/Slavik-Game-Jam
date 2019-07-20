using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField]
    public float timeAdd;

    private ParticleSystem exposion;
    void Start()
    {
        exposion = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //Debug.Log(GameMenager.instance.timeLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exposion.Play();
            GameMenager.instance.AddTime(timeAdd);
            Destroy(gameObject, 0.2f);
        }

    }
}
