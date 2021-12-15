using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static bool win = false;
    public static bool lost = false;
    public static bool end = false;

    public static int score;
    public static int points_animal_save = 50; //A_S
    public static int points_animal_catch = 30; //A_C
    public static int points_collect_waterdrop = 50; //D
    public static int points_touch_stone = -10; //S
    public static int points_touch_wall = -10; //W
    public static int points_touch_fire = -10; //F

    public static int animal_to_catch_level_1 = 5;
    public static int animals_saved = 0;
    public static int animals_dead = 0;

    // Start is called before the first frame update
    public static void Init()
    {
        score = 100;
        animals_saved = 0;
        win = false;
        lost = false;
        end = false;
    }

    public static void ScoreUpdate(string type)
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

    public static void AnimalSaved()
    {
        ++animals_saved;
        Spawner.animal_limit--;
        end = isEnd(); 
    }

    public static void AnimalDead()
    {
        ++animals_dead;
        Spawner.animal_limit--;
        end = isEnd();
    }

    public static bool isEnd()
    {
        if (animals_saved + animals_dead >= animal_to_catch_level_1)
        {
            if(animals_saved> animals_dead)
            {
                win = true;
            }
            else
            {
                lost = true;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
