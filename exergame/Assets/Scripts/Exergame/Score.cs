using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int current_score;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneChanger.chatchSceneReloaded == 1)
        {
            ScoreManager.Init();
            current_score = ScoreManager.score;
        }     
        setScore(current_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(current_score != ScoreManager.score)
        {
            current_score = ScoreManager.score;
            setScore(current_score);
        }
    }

    public void setScore(int score)
    {
        gameObject.GetComponent<Text>().text = score.ToString("F0");
    }
}
