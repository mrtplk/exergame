using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputFront : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, vertical, 0) * (speed * Time.deltaTime));
    }
}
