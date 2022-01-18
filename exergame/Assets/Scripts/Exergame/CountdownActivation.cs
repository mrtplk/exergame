using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class CountdownActivation : MonoBehaviour
{
    public int countdownTime;
    public GameObject countdownDisplay;

    private Text ct;
    private IEnumerator coroutine;

    void Start()
    {
        countdownTime = 3;
        countdownDisplay.gameObject.SetActive(false);
        ct = countdownDisplay.GetComponent<Text>();
        coroutine = CountdownToStart();

        ActivateCountdown();
    }

    private IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            ct.text = countdownTime.ToString();
            SoundManager.PlaySound(SoundManager.Sound._123Sound);
            yield return new WaitForSeconds(2f);
            countdownTime--;
        }

        ct.text = "GO!";
        SoundManager.PlaySound(SoundManager.Sound.GOSound);
        yield return new WaitForSeconds(4f);
        SceneChanger.LoadCatchScene();
    }

    public void ActivateCountdown()
    {
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(coroutine);
    }

    private void DelayActivateCountdown()
    {
        Invoke("ActivateCountdown", 5.0f);
    }
}
