using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UI;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("Game Assets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }

    public GameObject game_area;
    public float game_area_width = 581.0f, game_area_height = 289.0f;
    private RectTransform rect_transform;

    
    void Start()
    {
        
        rect_transform = game_area.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        game_area_width = rect_transform.sizeDelta.x;
        game_area_height = rect_transform.sizeDelta.y;
        
    }

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;

    }

}
