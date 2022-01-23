using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementMap : MonoBehaviour
{
    public GameObject scene3;
    public GameObject scene4;
    public GameObject scene5;
    public GameObject scene6;

    public GameObject checkpoint1;
    public GameObject checkpoint2;

    public GameObject footstep1;
    public GameObject footstep2;
    public GameObject footstep3;

    public GameObject player;
    public float speed = 20.0f;

    public int hit_counter = 0;
    public int restart_counter = 0;

    public Vector3 start_point_pos;

    public GameObject prompt_controller;
    private PromptControllerMap prompt_controller_script;

    private int take_care_counter;
    private int watch_out_counter;

    private TrackerPlayerPosition tpp_script;

    public GameObject lights_controller;
    private LightControll lights_controller_script;


    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        scene4.SetActive(false);
        scene5.SetActive(false);
        scene6.SetActive(false);

        hit_counter = 0;
        restart_counter = 0;

        start_point_pos = GameObject.Find("startpoint").transform.position;
        print(start_point_pos);
        player.transform.position = start_point_pos;

        footstep2.SetActive(false);
        footstep3.SetActive(false);

        take_care_counter = 0;
        watch_out_counter = 0;

        prompt_controller_script = prompt_controller.GetComponent<PromptControllerMap>();
        tpp_script = player.GetComponent<TrackerPlayerPosition>();

        lights_controller_script = lights_controller.GetComponent<LightControll>();
        tpp_script.enabled = false;
        DelayEnableKinectScript();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > checkpoint1.transform.position.x)
        {
            footstep1.SetActive(false);
            footstep2.SetActive(true);
            footstep3.SetActive(false);
        }
        else if (player.transform.position.x > checkpoint2.transform.position.x)
        {
            footstep1.SetActive(false);
            footstep2.SetActive(false);
            footstep3.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Waterdrop")
        {
            //COLOR BLUE - MAYBE NOT!
            lights_controller_script.ActivateLightFeedback(Color.blue);
            ScoreManager.ScoreUpdate("D");
            collision.gameObject.gameObject.SetActive(false);
            int n = Random.Range(0, 10);
            if (n%2 == 0)
            {
                SoundManager.PlaySound(SoundManager.Sound.GreatSound);
                prompt_controller_script.showPrompt(0);
            }
            else
            {
                SoundManager.PlaySound(SoundManager.Sound.ExcellentSound);
                prompt_controller_script.showPrompt(1);
            }
        }

        if (collision.gameObject.tag == "Fire")
        {
            //COLOR RED
            lights_controller_script.ActivateLightFeedback(Color.red);
            ScoreManager.ScoreUpdate("F");
            collision.gameObject.gameObject.SetActive(false);
            if (take_care_counter == 3)
            {
                SoundManager.PlaySound(SoundManager.Sound.TakeCareSound);
                take_care_counter = 0;
            }
            else
            {
                take_care_counter++;
                SoundManager.PlaySound(SoundManager.Sound.FireTouch);
            }
            prompt_controller_script.showPrompt(3);
        }

        if (collision.gameObject.tag == "Stone")
        {
            //COLOR RED
            lights_controller_script.ActivateLightFeedback(Color.red);
            ScoreManager.ScoreUpdate("S");
            collision.gameObject.gameObject.SetActive(false);

            if (take_care_counter == 3)
            {
                SoundManager.PlaySound(SoundManager.Sound.TakeCareSound);
                take_care_counter = 0;
            }
            else
            {
                take_care_counter++;
                SoundManager.PlaySound(SoundManager.Sound.StoneTouch);
            }
            prompt_controller_script.showPrompt(3);       
        }

        if (collision.gameObject.tag == "Wall")
        {
            tpp_script.enabled = false;
            ScoreManager.ScoreUpdate("W");
            hit_counter += 1;
            SoundManager.PlaySound(SoundManager.Sound.WallHitSound);
            prompt_controller_script.showPrompt(3);

            if (hit_counter >= 10)
            {
                //COLOR RED
                lights_controller_script.ActivateLightFeedback(Color.red);
                if (hit_counter!=10)
                {
                    SoundManager.PlaySound(SoundManager.Sound.TakeCareSound);
                    prompt_controller_script.showPrompt(3);
                }
                              
                {
                    if (player.transform.position.x > checkpoint1.transform.position.x)
                    {
                        player.transform.position = checkpoint1.transform.position;
                    }
                    else if (player.transform.position.x > checkpoint2.transform.position.x)
                    {
                        player.transform.position = checkpoint2.transform.position;
                    }
                    
                }
                hit_counter = 0;
                restart_counter += 1;
            }

            DelayEnableKinectScript();

            if (restart_counter == 10)
            {
                ScoreManager.AnimalDead();
                SoundManager.PlaySound(SoundManager.Sound.TryAgainSound);
                prompt_controller_script.showPrompt(2);
                if (!ScoreManager.end)
                {
                    scene3.SetActive(false);
                    scene5.SetActive(true);
                    DelayGroundScene();
                }
                else
                {
                    //COLOR PINK
                    lights_controller_script.ActivateLightFeedback(Color.magenta);
                    SoundManager.PlaySound(SoundManager.Sound.CongratulationsSound);
                    scene3.SetActive(false);
                    scene6.SetActive(true);
                }
            }
        }

        if (collision.gameObject.name == "end_square")
        {
            SoundManager.PlaySound(SoundManager.Sound.AnimalIsHomeSound);
            ScoreManager.ScoreUpdate("A_S");
            ScoreManager.AnimalSaved();
            scene3.SetActive(false);
            scene4.SetActive(true);
            if (!ScoreManager.end)
            {
                //COLOR GREEN
                lights_controller_script.ActivateLightFeedback(Color.green);
                DelayGroundScene();
            }
            else
            {
                //COLOR PINK
                lights_controller_script.ActivateLightFeedback(Color.magenta);
                SoundManager.PlaySound(SoundManager.Sound.CongratulationsSound);
                scene3.SetActive(false);
                scene6.SetActive(true);
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("exit wall");
        }
    }

    private void DelayGroundScene()
    {
        Invoke("CallCatchScene", 3.0f);
    }

    private void CallCatchScene()
    {
        SceneChanger.LoadCatchScene();
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
