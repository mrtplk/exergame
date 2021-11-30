using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMap : MonoBehaviour
{
    public Vector3 player_pos;
    public float speed = 20.0f;
    // public GameObject score_manager;

    // private ScoreManager s_m;

    public int hit_counter = 0;
    public int restart_counter = 0;

    public Vector3 start_point_pos;

    // Start is called before the first frame update
    void Start()
    {
        player_pos = gameObject.transform.position;
        hit_counter = 0;
        restart_counter = 0;

        start_point_pos = GameObject.Find("startpoint").transform.position;
        print(start_point_pos);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            print("up");
            player_pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            player_pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player_pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player_pos.x -= speed * Time.deltaTime;
        }

        transform.position = player_pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        print(collision.gameObject.tag);
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Wall")
        {
            print("enter wall");
            hit_counter += 1;

            if(hit_counter >= 3) {
                player_pos.x = start_point_pos.x;
                player_pos.y = start_point_pos.y;

                hit_counter = 0;
                restart_counter += 1;
            }

            if(restart_counter == 3) {
                print("Lost game");
            }
        }

        if (collision.gameObject.name == "end_square")
        {
            print("Win!!!!");
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
