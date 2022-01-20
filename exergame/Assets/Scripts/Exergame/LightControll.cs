using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Check if it looks ok
        ActivateFixedLights(Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateFixedLights(Color c)
    {
        MagicRoomManager.instance.MagicRoomLightManager.SendColor(c);
    }

    public void ActivateLightFeedback(Color c)
    {
        StartCoroutine(FlashLights(c));
    }

    IEnumerator FlashLights(Color c)
    {
        MagicRoomManager.instance.MagicRoomLightManager.SendColor(c);
        yield return new WaitForSeconds(2.0f);
        MagicRoomManager.instance.MagicRoomLightManager.SendColor(Color.black);
    }

}
