using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 position;
    public float speed = 20.0f;
    public GameObject animal_spawner;
    //public GameObject score_manager;

    private Spawner a_s_s;
    //private ScoreManager s_m;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        a_s_s = animal_spawner.GetComponent<Spawner>();
        //s_m = score_manager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            position.z += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.z -= speed * Time.deltaTime;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
            a_s_s.Stop();
            ScoreManager.ScoreUpdate("A_C");
            // SceneManager.LoadScene("MapScene"); //activate map
            // Time.timeScale = 0; //freeze scene
        }

        if (collision.gameObject.tag == "Fire")
        {
            print("fire");
            ScoreManager.ScoreUpdate("F");
        }

        if (collision.gameObject.tag == "Stone")
        {
            print("stone");
            ScoreManager.ScoreUpdate("S");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
            a_s_s.Resume();
            // SceneManager.LoadScene("MapScene"); //desactivate map
            // Time.timeScale = 0; //unfreeze scene
        }
    }


}
