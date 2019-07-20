using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{

    private ParticleSystem exposion;
    void Start () {
       exposion = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //Debug.Log(GameMenager.instance.timeLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag ("Player")) {
              exposion.Play();
        }
        
    }

     
}
