using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerMap : MonoBehaviour
{
    public GameObject game_area;
    public GameObject fire_prefab;
    public GameObject[] stone_prefab;

    public int stone_limit = 5;
    public int fire_limit = 4;

    public float fire_spawn_time = 5.0f;

    public float game_area_width, game_area_height;
    private RectTransform rect_transform;

    // Start is called before the first frame update
    void Start()
    {
        rect_transform = game_area.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        game_area_width = 10;
        game_area_height = 10;
        SpawnFire();
        SpawnStones();
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
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            int stoneVariant = Mathf.CeilToInt(Random.Range(0, 3));
            if (stoneVariant > 2)
            {
                stoneVariant = 2;
            }
            GameObject new_stone = Instantiate(stone_prefab[stoneVariant], position, rotation);
            new_stone.transform.parent = transform;
            new_stone.transform.localScale = new Vector3(0.31f, 0.31f, 0.31f);
        }
    }



    Vector3 GetRandomPositionObstacle()
    {
        float screenX, screenY;
        Vector3 position;

        screenX = Random.Range(-game_area_width / 2.0f, game_area_width / 2.0f);
        screenY = Random.Range(-game_area_height/2.0f, game_area_height/2.0f);
        position = new Vector3((float)screenX, (float)screenY, 0) ;
        return position;
    }


    FireMovement AddFire(Vector3 position)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        GameObject new_fire = Instantiate(fire_prefab, position, rotation);
        new_fire.transform.parent = transform;
        new_fire.transform.localScale = new Vector3(0.21f, 0.21f, 0.21f);
        FireMovement fire_script = new_fire.GetComponent<FireMovement>();
        return fire_script;
    }

    public void Stop()
    {
        CancelInvoke();
    }
    
    public void destroyStones()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Stone"))
        {
            Destroy(o);
        }
    }

    public void destroyFire()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Fire"))
        {
            Destroy(o);
        }
    }
}
