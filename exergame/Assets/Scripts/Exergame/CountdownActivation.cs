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
    }

    private IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            ct.text = countdownTime.ToString();
            yield return new WaitForSeconds(2f);
            countdownTime--;
        }

        ct.text = "GO!";
        yield return new WaitForSeconds(4f);
        SceneChanger.LoadCatchScene();
    }

    public void ActivateCountdown()
    {
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(coroutine);
    }
}
