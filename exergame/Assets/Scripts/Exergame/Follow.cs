using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject spawner;
    private Spawner spawner_script;

    public GameObject track;
    private Vector3 current_position;

    void Start()
    {
        spawner_script = spawner.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        current_position = track.transform.position;
        if(current_position.z  < -GameAssets.i.game_area_height / 2.0f)
        {
            current_position.z = (float)-GameAssets.i.game_area_height / 2.0f;
        }

        if (current_position.z > GameAssets.i.game_area_height / 2.0f)
        {
            current_position.z = (float)GameAssets.i.game_area_height / 2.0f;
        }

        if (current_position.x < -GameAssets.i.game_area_width / 2.0f)
        {
            current_position.x = (float)-GameAssets.i.game_area_width / 2.0f;
        }

        if (current_position.x > GameAssets.i.game_area_width / 2.0f)
        {
            current_position.x = (float)GameAssets.i.game_area_width / 2.0f;
        }

        gameObject.transform.position = current_position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
            ScoreManager.ScoreUpdate("A_C");
            //spawner_script.destroyStones();
            //spawner_script.destroyFire();
            //spawner_script.destroyAnimals();
            SceneChanger.LoadMapScene(); //activate map
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
