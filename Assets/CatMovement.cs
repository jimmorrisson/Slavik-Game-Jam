using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CatMovement : MonoBehaviour
{
     float currentSpeed = 2.0f;
     //float targetSpeed = 1f;

    public Transform target;

    void Start () {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    void Update () {
        /* if (currentSpeed > targetSpeed)
             currentSpeed -= Time.deltaTime;*/
        transform.Translate(new Vector3(0,0, currentSpeed * Time.deltaTime));
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "WayPoint") {
            target = other.gameObject.GetComponent<WayPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            //currentSpeed = 5.0f;
        }

        if(other.tag == "Player") {
            Destroy(gameObject, 0.9f);
        }
    }
}
