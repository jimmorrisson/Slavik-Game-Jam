using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed = 10.0f;
    [SerializeField]
    public float rotationSpeed = 5.0f;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movementVertical = Input.GetAxis("Vertical") * movementSpeed;
        float movementHorizonal = Input.GetAxis("Horizontal") * rotationSpeed;
        //rigidbody.velocity = transform.forward * movementHorizonal;
        rigidbody.MovePosition(rigidbody.position + transform.forward * movementVertical * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForceAtPosition(transform.forward * 10, transform.position, ForceMode.Impulse);
        }

        gameObject.transform.Rotate(0, movementHorizonal, 0, Space.Self);
    }
}
