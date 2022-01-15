using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    public static int chatchSceneReloaded = 0;
    public static int mapSceneReloaded = 0;

    public static void LoadMapScene()
    {
        mapSceneReloaded++;
        SceneManager.LoadScene("OfficialGameScene2");
    }

    public static void LoadCatchScene()
    {
        chatchSceneReloaded++;
        SceneManager.LoadScene("OfficialGameScene");
    }

}

