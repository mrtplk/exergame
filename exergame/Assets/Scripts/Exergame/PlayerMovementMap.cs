using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMap : MonoBehaviour
{
    public GameObject  scene3;
    public GameObject  scene4;

    public GameObject player;
    public float speed = 20.0f;
    // public GameObject score_manager;

    // private ScoreManager s_m;

    public int hit_counter = 0;
    public int restart_counter = 0;

    public Vector3 start_point_pos;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        scene4.SetActive(false);
        hit_counter = 0;
        restart_counter = 0;

        start_point_pos = GameObject.Find("startpoint").transform.position;
        print(start_point_pos);
        player.transform.position= start_point_pos;
    }

    // Update is called once per frame
    void Update()
    {

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
                player.transform.position = start_point_pos;

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
            scene3.SetActive(false);
            scene4.SetActive(true);
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
