using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float trhust_speed;
    [SerializeField] float rotation_speed;



    // Start is called before the first frame update
    void Start()
    {
        // Initialize RigidBody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call Thrust Method
        ProcessThrust();
        // Call Rotation Method
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        // If Up Arrow or W or Space are pressed
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Thrust");
            rb.AddRelativeForce(Vector3.up * trhust_speed * Time.deltaTime);
        }

    }

    private void ProcessRotation()
    {
        // If Right Arrow or D are pressed
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotate Forward");
            ApplyRotation(-1);
        }
        // If Left Arrow or A are pressed
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotate Backward");
            ApplyRotation(1);
        }
    }

    private void ApplyRotation(int direction)
    {
        // Apply the rotation to the rocket , but to avoid bugs on physics system freeze the current rotation before our rotation and release after our rotation
        rb.freezeRotation = true; // Freezing rotation
        transform.Rotate(direction * Vector3.forward * rotation_speed * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation
    }
}
