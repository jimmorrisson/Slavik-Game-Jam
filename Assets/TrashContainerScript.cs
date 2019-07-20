using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashContainerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            GameMenager.instance.EmptyTheContainer();
    }
}
