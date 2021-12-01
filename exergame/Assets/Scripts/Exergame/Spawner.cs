using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject game_area;
    public GameObject animal_prefab;
    public GameObject fire_prefab;
    public GameObject stone_prefab;

    public int animal_limit = 10;
    public int stone_limit = 5;
    public int fire_limit = 4;

    public int animal_count;

    public float animal_spawn_time = 5.0f;
    public float fire_spawn_time = 5.0f;

    public float game_area_width, game_area_height;
    private RectTransform rect_transform;

    // Start is called before the first frame update
    void Start()
    {
        animal_count = 0;
        rect_transform = game_area.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        game_area_width = rect_transform.sizeDelta.x;
        game_area_height = rect_transform.sizeDelta.y;
        InvokeRepeating("MaintainAnimalPopulation", animal_spawn_time, animal_spawn_time);
        SpawnFire();
        SpawnStones();
    }

    void MaintainAnimalPopulation()
    {
        if (animal_count < animal_limit)
        {
            Vector3 position = GetRandomPositionAnimal();
            AnimalMovement new_animal = AddAnimal(position);
        }
    }

    void SpawnFire()
    {
        for(int i=0; i < fire_limit; i++)
        {
            Vector3 position = GetRandomPositionObstacle();
            FireMovement new_fire = AddFire(position);
        }
    }

    void SpawnStones()
    {
        for (int i = 0; i < stone_limit; i++)
        {
            Vector3 position = GetRandomPositionObstacle();
            Quaternion rotation = Quaternion.Euler(90, 0, 0);
            GameObject new_stone = Instantiate(stone_prefab, position, rotation);
        }
    }

    Vector3 GetRandomPositionAnimal()
    {
        int rand_variant = Random.Range(0, 4);
        Vector3 position;
        if (rand_variant == 0)
        {
            float rand_x = Random.Range((float)-game_area_width / 2.0f, (float)game_area_width / 2.0f); //game_panel's center in 0.0f
            position = new Vector3((float)rand_x, (float)-game_area_height / 2.0f, -2.0f);
        }
        else if (rand_variant == 1)
        {
            float rand_x = Random.Range((float)-game_area_width / 2.0f, (float)game_area_width / 2.0f);
            position = new Vector3((float)rand_x, (float)game_area_height/2.0f, -2.0f);
        }
        else if(rand_variant == 2)
        {
            float rand_y = Random.Range((float)-game_area_height / 2.0f, (float)game_area_height/2.0f);
            position = new Vector3((float)game_area_width/2, (float)rand_y, -2.0f);
        }
        else
        {
            float rand_y = Random.Range((float)-game_area_height / 2.0f, (float)game_area_height / 2.0f);
            position = new Vector3((float)-game_area_width / 2, (float)rand_y, -2.0f);
        }
        
        return position;
    }

    Vector3 GetRandomPositionObstacle()
    {
        float screenX, screenY;
        Vector3 position;

        screenX = Random.Range(-game_area_width / 2.0f, game_area_width / 2.0f);
        screenY = Random.Range(-game_area_height/2.0f, game_area_height/2.0f);
        position = new Vector3(screenX, screenY, -2);
        return position;
    }



    AnimalMovement AddAnimal(Vector3 position)
    {
        animal_count += 1;
        Quaternion rotation = Quaternion.Euler(90, 0, 0);
        GameObject new_animal = Instantiate(animal_prefab, position, rotation);
        AnimalMovement animal_script = new_animal.GetComponent<AnimalMovement>();
        return animal_script;
    }

    FireMovement AddFire(Vector3 position)
    {
        Quaternion rotation = Quaternion.Euler(90, 0, 0);
        GameObject new_fire = Instantiate(fire_prefab, position, rotation);
        FireMovement fire_script = new_fire.GetComponent<FireMovement>();
        return fire_script;
    }

    public void Stop()
    {
        CancelInvoke();
    }

    public void Resume()
    {
        InvokeRepeating("MaintainAnimalPopulation", animal_spawn_time, animal_spawn_time);
    }

    /*
    private void destroyStones()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Stone"))
        {
            Destroy(o);
        }
    }

    private void destroyFire()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Fire"))
        {
            Destroy(o);
        }
    }
    */
}
