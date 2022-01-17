using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptControllerMap : MonoBehaviour
{
    public List<GameObject> promptMessages = new List<GameObject>();
    private List<Image> promptMessageImages = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < promptMessages.Count; i++)
        {
            if (promptMessages[i])
            {
                promptMessageImages.Add(promptMessages[i].GetComponent<Image>());
                promptMessageImages[i].color = new Color(1, 1, 1, 0);
            }
        }

    }


    public void showPrompt(int prompt_number)
    {
        promptMessageImages[prompt_number].color = new Color(1, 1, 1, 1);
        StartCoroutine(FadeImage(promptMessageImages[prompt_number], true));
    }

    IEnumerator FadeImage(Image img, bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }


}

