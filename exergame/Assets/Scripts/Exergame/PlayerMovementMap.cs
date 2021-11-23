using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMap : MonoBehaviour
{
    public Vector3 position;
    public float speed = 20.0f;
    // public GameObject score_manager;

    // private ScoreManager s_m;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("up");
            position.y += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y -= speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position.x += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position.x -= speed * Time.deltaTime;
        }

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        if (collision.gameObject.tag == "Wall")
        {
            print("enter wall");
            // s_m.ScoreUpdate("A_C");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("exit wall");
        }
    }


}
