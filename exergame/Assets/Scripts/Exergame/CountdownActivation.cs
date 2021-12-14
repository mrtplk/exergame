using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownActivation : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCountdown()
    {
        //countdown[animation_name].wrapMode = WrapMode.Once;
        // gameObject.SetActive(true);
        SceneChanger.LoadCatchScene();
        // Destroy(gameObject);
    }
}
