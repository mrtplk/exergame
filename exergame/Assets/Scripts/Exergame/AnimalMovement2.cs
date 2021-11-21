using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement2 : MonoBehaviour
{
    public float force = 2.0f;
    public float repeatRate = 3.0f;
    public Vector3 direction;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    { 
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("FindRanomPosition", 0f, repeatRate);
    }

    void FindRanomPosition()
    {
        direction = new Vector3((float)Random.Range(-15.0f, 15.0f), (float)Random.Range(-15.0f, 15.0f), -2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction* force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CancelInvoke();
        direction = new Vector3((float)Random.Range(-50.0f, 50.0f), (float)Random.Range(-50.0f, 50.0f), -2.0f);
        // rb.AddForce(direction * force);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        InvokeRepeating("FindRanomPosition", 1f, repeatRate);
    }
}
