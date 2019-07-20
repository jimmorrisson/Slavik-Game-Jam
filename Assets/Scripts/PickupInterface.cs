using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Shooting
}

public interface PickupInterface
{
    float Duration { get; set; }

    PickupType Type { get; set; }

    void OnPickup();
}
