using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float force = 2.0f;
    public float rotationSpeed = 5.0f;
    public float repeatRate = 3.0f;
    public Vector3 prev_direction, direction;

    private Rigidbody rb;
    private bool sectorChanged = true;

    // Start is called before the first frame update
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("FindRanomPosition", 0f, repeatRate);
    }

    void FindRanomPosition()
    {
        prev_direction = direction;
        direction = new Vector3((float)Random.Range(-15.0f, 15.0f), (float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-15.0f, 15.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(direction != Vector3.zero)
        {
            Quaternion toRotation;
            //left, down
            if (prev_direction.x>direction.x && prev_direction.z > direction.z)
            {
                /*
                if(direction.x > 0 && direction.z>0)
                {
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime) * Quaternion.Euler(0, 0, 225.0f);
                }
                else if (direction.x > 0 && direction.z < 0)
                {
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime) * Quaternion.Euler(0, 0, 135.0f);
                }
                else if (direction.x < 0 && direction.z < 0)
                {
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime) * Quaternion.Euler(0, 0, 225.0f);
                }
                else if (direction.x < 0 && direction.z > 0)
                {
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime) * Quaternion.Euler(0, 0, 315.0f);
                }
                */
                toRotation = Quaternion.LookRotation(direction, -Vector3.forward + Vector3.left);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 315.0f);
            }
            //right, down
            else if (prev_direction.x < direction.x && prev_direction.z > direction.z)
            {
                toRotation = Quaternion.LookRotation(direction, -Vector3.forward + Vector3.right);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 315.0f);
            }
            //right, up
            else if (prev_direction.x < direction.x && prev_direction.z < direction.z)
            {
                toRotation = Quaternion.LookRotation(direction, Vector3.forward+Vector3.right);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 45.0f);
            }
            //left, up
            else if (prev_direction.x > direction.x && prev_direction.z < direction.z)
            {
                toRotation = Quaternion.LookRotation(direction, Vector3.forward + Vector3.left);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 315.0f);
            }

            //Quaternion toRotation = Quaternion.LookRotation(centreOfRotationPosition*45, Vector3.forward);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);
        }
        rb.AddForce(direction* force);
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
