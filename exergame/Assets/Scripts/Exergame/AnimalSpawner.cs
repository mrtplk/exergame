using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject game_area;
    public GameObject animal_prefab;
    public int animal_count = 0;
    public int animal_limit = 10;
    public float animal_spawn_time = 5.0f;

    private float game_area_x_min, game_area_x_max;
    private float game_area_y_min, game_area_y_max;
    private float game_area_width, game_area_height;
    private RectTransform rect_transform;

    // Start is called before the first frame update
    void Start()
    {
        rect_transform = game_area.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        game_area_width = rect_transform.sizeDelta.x;
        game_area_height = rect_transform.sizeDelta.y;
        InvokeRepeating("MaintainPopulation", animal_spawn_time, animal_spawn_time);
    }

    void MaintainPopulation()
    {
        if (animal_count < animal_limit)
        {
            Vector3 position = GetRandomPosition();
            AnimalMovement2 new_animal = AddAnimal(position);
        }
    }

    Vector3 GetRandomPosition()
    {
        int rand_variant = Random.Range(0, 4);
        print(rand_variant);
        Vector3 position;
        if (rand_variant == 0)
        {
            float rand_x = Random.Range(0.0f, (float)game_area_width); //game_panel's center in 0.0f
            position = new Vector3((float)rand_x, 0.0f, -2.0f);
        }
        else if (rand_variant == 1)
        {
            float rand_x = Random.Range(0.0f, (float)game_area_width);
            position = new Vector3((float)rand_x, (float)game_area_height, -2.0f);
        }
        else if(rand_variant == 2)
        {
            float rand_y = Random.Range(0.0f, (float)game_area_height);
            position = new Vector3((float)game_area_height, (float)rand_y, -2.0f);
        }
        else
        {
            float rand_y = Random.Range(0.0f, (float)game_area_height);
            position = new Vector3(0.0f, (float)rand_y, -2.0f);
        }
        
        return position;
    }

    
    AnimalMovement2 AddAnimal(Vector3 position)
    {
        animal_count += 1;
        GameObject new_animal = Instantiate(animal_prefab, position, Quaternion.identity);
        AnimalMovement2 animal_script = new_animal.GetComponent<AnimalMovement2>();
        return animal_script;
    }

    public void Stop()
    {
        CancelInvoke();
    }

    public void Resume()
    {
        InvokeRepeating("MaintainPopulation", animal_spawn_time, animal_spawn_time);
    }

}
