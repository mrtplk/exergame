using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject track;
    private Vector3 current_position;

    // Update is called once per frame
    void Update()
    {
        current_position = track.transform.position;
        //scale to fit the screen - TO DO!!!!!
        //current_position.x = current_position.x / 100;
        //current_position.z = current_position.z / 100;
        gameObject.transform.position = current_position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
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

    private void OnCollisionExit(Collision2D collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
            // SceneManager.LoadScene("MapScene"); //desactivate map
            // Time.timeScale = 0; //unfreeze scene
        }
    }
}
