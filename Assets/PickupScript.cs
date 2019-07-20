using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Shoot,
    Boost
}

public class PickupScript : MonoBehaviour
{
    public float durationTime;

    public PickupType pickupType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (pickupType == PickupType.Shoot)
            {
                var carShootingScript = other.GetComponent<CarShootingScript>();
                carShootingScript.enabled = true;
                carShootingScript.Duration = durationTime;
                Destroy(gameObject);
            }
            else if (pickupType == PickupType.Boost)
            {
                var carMovement = other.GetComponent<CarMovement>();
                carMovement.BoostTime = durationTime;
                Destroy(gameObject);
            }
        }
    }
}
