using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneChanger
{
    public static void LoadMapScene()
    {
        SceneManager.LoadScene("OfficialGameScene2");
    }

    public static void LoadCatchScene()
    {
        SceneManager.LoadScene("OfficialGameScene");
    }
}

