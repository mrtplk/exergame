using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMovement : MonoBehaviour
{
    public Vector3 position;

    public GameObject game_area;

    public float invoke_rate = 5.0f;

    private float game_area_width, game_area_height;
    private RectTransform rect_transform;


    // Start is called before the first frame update
    void Start()
    {
        rect_transform = game_area.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        game_area_width = rect_transform.sizeDelta.x;
        game_area_height = rect_transform.sizeDelta.y;
        InvokeRepeating("FindRanomPosition", 0f, invoke_rate);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = position;
    }

    void FindRanomPosition()
    {
        int shouldChange = Random.Range(0, 2);
        if (shouldChange == 1)
        {
            position = new Vector3((float)Random.Range(-game_area_width / 2.0f, game_area_width / 2.0f),-2.0f, (float)Random.Range(-game_area_height / 2.0f, game_area_height / 2.0f));
        }
    }
}
