using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PickupInterface
{
    float Duration { get; set; }
    void OnPickup();
}
