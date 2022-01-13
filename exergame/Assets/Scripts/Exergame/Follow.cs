using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject spawner;
    private Spawner spawner_script;

    public GameObject track;
    private Vector3 current_position;

    public GameObject prompt_controller;
    private PromptController prompt_controller_script;

    void Start()
    {
        spawner_script = spawner.GetComponent<Spawner>();
        prompt_controller_script = prompt_controller.GetComponent<PromptController>();
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
            //TO DO: NOT WORKING!!!
            int n = Random.Range(0, 1);
            prompt_controller_script.showPrompt(collision.gameObject.transform.position, n);
            //
            SceneChanger.LoadMapScene(); //activate map
        }

        if (collision.gameObject.tag == "Fire")
        {
            //TO DO: NOT WORKING!!!
            print("fire");
            prompt_controller_script.showPrompt(collision.gameObject.transform.position, 3);
            //
            SoundManager.PlaySound(SoundManager.Sound.FireTouch);
            ScoreManager.ScoreUpdate("F");
        }

        if (collision.gameObject.tag == "Stone")
        {
            //TO DO: NOT WORKING!!!
            print("stone");
            prompt_controller_script.showPrompt(collision.gameObject.transform.position, 3);
            //
            SoundManager.PlaySound(SoundManager.Sound.StoneTouch);
            ScoreManager.ScoreUpdate("S");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
            // SceneManager.LoadScene("MapScene"); //desactivate map
            // Time.timeScale = 0; //unfreeze scene
        }
    }

    
}
