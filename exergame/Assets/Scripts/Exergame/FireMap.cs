using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMap : MonoBehaviour
{
    public Vector3 position;

    public float invoke_rate = 2f;

    private float game_area_width, game_area_height;


    // Start is called before the first frame update
    void Start()
    {
        game_area_width = 10;
        game_area_height = 10;
        InvokeRepeating("FindRandomPosition", 0f, invoke_rate);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = position;
    }

    void FindRandomPosition()
    {
        int shouldChange = Random.Range(0, 2);
        if (shouldChange == 1)
        {
            position = new Vector3(
                (float)Random.Range(-game_area_width / 2.0f, game_area_width / 2.0f),
                (float)Random.Range(-game_area_height / 2.0f, game_area_height / 2.0f),
                -2.0f);
        }
    }
}
