using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float force = 2.0f;
    public float rotationSpeed = 1.0f;
    public float repeatRate = 3.0f;
    public Vector3 direction;
    public Vector3 currentPosition, previousPosition;

    private Rigidbody rb;
    private bool sectorChanged = true;
    private int prev_sector=-1, current_sector=-1;

    // Start is called before the first frame update
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("FindRanomPosition", 0f, repeatRate);
        //InvokeRepeating("Rotate", 0f, repeatRate);
    }

    void FindRanomPosition()
    {
        direction = new Vector3((float)Random.Range(-15.0f, 15.0f), (float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-15.0f, 15.0f));
    }

    void Rotate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction* force);
        // transform.position = Vector3.Scale(transform.position, (Vector3.forward+ Vector3.right));
    }

    void FixedUpdate()
    {
        previousPosition = currentPosition;
        currentPosition = transform.position;
        Vector3 currentDirection = (currentPosition - previousPosition).normalized;
        transform.LookAt(transform.position + new Vector3(0, 1, 0), currentDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CancelInvoke();
        direction = new Vector3((float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-50.0f, 50.0f));
        rb.AddForce(direction * force);
    }

    private void OnCollisionExit(Collision collision)
    {
        InvokeRepeating("FindRanomPosition", 1f, repeatRate);
    }
}
