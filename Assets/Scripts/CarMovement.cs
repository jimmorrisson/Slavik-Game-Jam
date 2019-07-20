using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;
    [SerializeField]
    public float rotationSpeed;
    [SerializeField]
    public float dashCooldownTime;

    private float dashCooldown = 0;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleDashCooldown();
    }

    private void HandleMovement()
    {
        float movementVertical = Input.GetAxis("Fire2") * movementSpeed;
        float movementHorizonal = Input.GetAxis("Horizontal") * rotationSpeed;
        rigidbody.MovePosition(rigidbody.position + transform.forward * movementVertical * Time.deltaTime);

        float btnJump = Input.GetAxis("Jump");
        if (btnJump > 0.0f && dashCooldown == 0)
        {
            rigidbody.AddForceAtPosition(transform.forward * 10, transform.position, ForceMode.Impulse);
            GameMenager.instance.TakeFuel(1.2f);
            SetDashCooldown(dashCooldownTime);
        }

        gameObject.transform.Rotate(0, movementHorizonal, 0, Space.Self);
    }

    private void HandleDashCooldown()
    {
        if (dashCooldown > 0)
        {
            dashCooldown -= Time.deltaTime;
        }
        else
        {
            dashCooldown = 0;
        }
    }

    private void SetDashCooldown(float time)
    {
        dashCooldown = time;
    }
}
