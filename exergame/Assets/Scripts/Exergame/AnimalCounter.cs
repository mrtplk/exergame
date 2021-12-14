using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCounter : MonoBehaviour
{
    private int cought_animals;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneChanger.chatchSceneReloaded == 1)
        {
            cought_animals = 0;
            setScore(cought_animals);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cought_animals != ScoreManager.animals_saved)
        {
            cought_animals = ScoreManager.animals_saved;
            setScore(cought_animals);
        }
    }

    public void setScore(int animals_saved)
    {
        string txt = animals_saved.ToString("F0") + "/" + ScoreManager.animal_to_catch_level_1.ToString("F0");
        gameObject.GetComponent<Text>().text = txt;
    }
}
