using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBackgrounMusic : MonoBehaviour
{
    static PlayBackgrounMusic instance;

    // Singelton to keep instance alive through all scenes
    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        // Hooks up the 'OnSceneLoaded' method to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Plays different music in different scenes
        switch (scene.name)
        {
            case "ExergameStartScene":
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.BackgroundMusicStart);
                break;
            case "OfficialGameScene":
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.BackgroundMusicGround);
                break;
            case "OfficialGameScene2":
                SoundManager.PlayBackgroundMusic(SoundManager.Sound.BackgrounMusicFront);
                break;
            default:
                break;
        }
    }
}