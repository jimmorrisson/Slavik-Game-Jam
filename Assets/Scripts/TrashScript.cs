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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            exposion.Play();
            GameMenager.instance.OnTrashDestroyed(timeAdd, this.transform);
            Destroy(gameObject, 0.2f);
        }
    }
}
