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

    void Update()
    {
        if (coolDown > 0)
            coolDown -= Time.deltaTime;
        else
            Shoot();
    }

    private void Shoot()
    {
        if (coolDown > 0)
            return;

        Instantiate(bulletPrefab, transform.position, transform.rotation);
        coolDown = coolDownTime;
    }
}
