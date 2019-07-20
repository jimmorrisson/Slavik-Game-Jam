using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float speed;

    [SerializeField]
    public float destroyTime;

    private Rigidbody bulletRigid;

    void Start()
    {
        bulletRigid = GetComponent<Rigidbody>();
        bulletRigid.velocity = transform.forward * speed;

        Destroy(gameObject, destroyTime);
    }
}
