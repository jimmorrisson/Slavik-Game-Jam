using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float speed = 20.0f;

    [SerializeField]
    public float destroyTime = 1.0f;

    private Rigidbody bulletRigid;

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * speed;

        Destroy(gameObject, destroyTime);
    }
}
