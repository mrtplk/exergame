using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 100;
    public int points_animal_save = 50; //A_S
    public int points_animal_catch = 30; //A_C
    public int points_collect_waterdrop = 50; //D
    public int points_touch_stone = -10; //S
    public int points_touch_wall = -10; //W
    public int points_touch_fire = -10; //F


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUpdate(string type)
    {
        switch (type)
        {
            case "A_S":
                score += points_animal_save;
                break;
            case "A_C":
                score += points_animal_catch;
                break;
            case "D":
                score += points_collect_waterdrop;
                break;
            case "S":
                score += points_touch_stone;
                break;
            case "W":
                score += points_touch_wall;
                break;
            case "F":
                score += points_touch_fire;
                break;
            default:
                break;

        }
            
        
    }
}