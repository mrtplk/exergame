using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float force = 2.0f;
    public float repeatRate = 3.0f;
    public Vector3 direction;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody>();
        InvokeRepeating("FindRanomPosition", 0f, repeatRate);
    }

    void FindRanomPosition()
    {
        direction = new Vector3((float)Random.Range(-15.0f, 15.0f), (float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-15.0f, 15.0f));
    }

    // Update is called once per frame
    void Update()
    {
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
