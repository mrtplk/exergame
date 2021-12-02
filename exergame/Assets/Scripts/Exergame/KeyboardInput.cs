using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 30.0f;

    void Start()
    {
        direction = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.forward;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.back;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            transform.Translate(direction * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }
}
