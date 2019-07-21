using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    [SerializeField]
    public float timeAdd;

    public AudioSource audioSource;

    private ParticleSystem exposion;
    void Start()
    {
        exposion = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            exposion.Play();
            audioSource.Play();
            GameMenager.instance.AddFuel(2);
            GameMenager.instance.OnTrashDestroyed(timeAdd, this.transform);
            Destroy(gameObject, 0.2f);
        }
    }
}
