using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject spawner;
    private Spawner spawner_script;

    public GameObject track;
    private Vector3 current_position;

    private TrackerPlayerPosition tpp_script;

    public GameObject prompt_controller;
    private PromptController prompt_controller_script;

    public GameObject lights_controller;
    private LightControll lights_controller_script;


    private int take_care_counter;

    void Start()
    {
        take_care_counter = 0;
        spawner_script = spawner.GetComponent<Spawner>();
        prompt_controller_script = prompt_controller.GetComponent<PromptController>();
        lights_controller_script = lights_controller.GetComponent<LightControll>();
        tpp_script = track.GetComponent<TrackerPlayerPosition>();
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
            ScoreManager.ScoreUpdate("A_C");
            //spawner_script.destroyStones();
            //spawner_script.destroyFire();
            //spawner_script.destroyAnimals();

            //COLOR GREEN
            lights_controller_script.ActivateLightFeedback(Color.green);
            int n = Random.Range(0, 2);
            if (n == 0)
            {
                SoundManager.PlaySound(SoundManager.Sound.GreatSound);
                prompt_controller_script.showPrompt(collision.gameObject.transform.position, n);
            }
            else if (n == 1)
            {
                SoundManager.PlaySound(SoundManager.Sound.ExcellentSound);
                prompt_controller_script.showPrompt(collision.gameObject.transform.position, n);
            }
            
            DelayMap();
        }
        //DISABLE KINECT SCRIPT FOR A SECOND
        else
        {
            //tpp_script.enabled = false;
            // DelayEnableKinectScript();
        }

        if (collision.gameObject.tag == "Fire")
        {
            //COLOR RED
            lights_controller_script.ActivateLightFeedback(Color.red);

            if (take_care_counter == 10)
            {
                SoundManager.PlaySound(SoundManager.Sound.TakeCareSound);
                take_care_counter = 0;
            }
            else
            {
                take_care_counter++;
                SoundManager.PlaySound(SoundManager.Sound.FireTouch);
            }
            prompt_controller_script.showPrompt(collision.gameObject.transform.position, 3);
            ScoreManager.ScoreUpdate("F");
        }

        if (collision.gameObject.tag == "Stone")
        {
            //COLOR RED
            lights_controller_script.ActivateLightFeedback(Color.red);

            if (take_care_counter == 10)
            {
                SoundManager.PlaySound(SoundManager.Sound.TakeCareSound);
                take_care_counter = 0;
            }
            else
            {
                take_care_counter++;
                SoundManager.PlaySound(SoundManager.Sound.StoneTouch);
            }
            prompt_controller_script.showPrompt(collision.gameObject.transform.position, 3);
            
            ScoreManager.ScoreUpdate("S");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            print("animal");
        }
    }

    private void DelayMap()
    {
        Invoke("CallMap", 3f);
    }

    private void CallMap()
    {
        SceneChanger.LoadMapScene();
    }

    private void DelayEnableKinectScript()
    {
        Invoke("EnableKinectScript", 0.75f);
    }

    private void EnableKinectScript()
    {
        tpp_script.enabled = true;
    }


}
