using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float durationTime;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var carShootingScript = other.GetComponent<CarShootingScript>();
            carShootingScript.enabled = true;
            carShootingScript.Duration = durationTime;
        }
    }
}
