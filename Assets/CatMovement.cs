using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CatMovement : MonoBehaviour
{
     float currentSpeed = 2.5f;
     //float targetSpeed = 1f;

    public Transform target;
    ParticleSystem blood;

    void Start () {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        blood = GetComponent<ParticleSystem>();
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
            if (GameMenager.instance.PowerScorePref) {
                GameMenager.instance.ShowPowerScore();
            }
            blood.Play();
            Destroy(gameObject, 0.6f);
            GameMenager.instance.TakeFuel(10);
        }
    }
}
