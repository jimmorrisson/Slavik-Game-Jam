using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShootingScript : MonoBehaviour
{
    [SerializeField]
    public Transform carTip;

    [SerializeField]
    public GameObject bulletPrefab;

    [SerializeField]
    public float coolDownTime = 1;

    private float coolDown = 0;

    public float Duration { get; set; } = 0;

    void Update()
    {
        HandleTimers();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (coolDown <= 0 && Duration > 0)
            Shoot();
    }

    private void HandleTimers()
    {
        if (coolDown > 0)
            coolDown -= Time.deltaTime;
        if (Duration > 0)
            Duration -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (coolDown > 0)
            return;

        Instantiate(bulletPrefab, carTip.transform.position, transform.rotation);
        coolDown = coolDownTime;
    }
}
