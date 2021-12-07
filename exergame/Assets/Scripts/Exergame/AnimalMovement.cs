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
    private int prev_sector=-1, current_sector=-1;

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
        if (direction != Vector3.zero)
        {
            prev_sector = current_sector;
            Quaternion toRotation;
            //SECTOR 1
            if (gameObject.transform.localPosition.x > 0 && gameObject.transform.localPosition.z > 0)
            {
                current_sector = 1;
            }
            //SECTOR 2
            if (gameObject.transform.localPosition.x > 0 && gameObject.transform.localPosition.z < 0)
            {
                current_sector = 2;
            }
            //SECTOR 3
            if (gameObject.transform.localPosition.x < 0 && gameObject.transform.localPosition.z < 0)
            {
                current_sector = 3;
            }
            //SECTOR 4
            if (gameObject.transform.localPosition.x < 0 && gameObject.transform.localPosition.z > 0)
            {
                current_sector = 4;
            }
            if(prev_sector != current_sector)
            {
                sectorChanged = true;
            }
            else
            {
                sectorChanged = false;
            }
            print(sectorChanged);
            if (sectorChanged)
            {
                //left, down
                if (prev_direction.x > direction.x && prev_direction.z > direction.z)
                {
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
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward + Vector3.right);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 45.0f);
                }
                //left, up
                else if (prev_direction.x > direction.x && prev_direction.z < direction.z)
                {
                    toRotation = Quaternion.LookRotation(direction, Vector3.forward + Vector3.left);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);// * Quaternion.Euler(0, 0, 315.0f);
                }
            }
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
