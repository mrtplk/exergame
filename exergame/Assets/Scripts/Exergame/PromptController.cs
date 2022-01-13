using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PromptController : MonoBehaviour
{
    public List<GameObject> promptMessages;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {        for (int i = 0; i < promptMessages.Count; i++)
        {
            if (promptMessages[i])
            {
                promptMessages[i].gameObject.SetActive(false);
            }
            //Color color =promptMessages[i].color;
            //color.a = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showPrompt(Vector3 pos, int prompt_number)
    {
        promptMessages[prompt_number].gameObject.SetActive(true);
        promptMessages[prompt_number].transform.position = new Vector3(pos.x, pos.y, 0);
        Image im = promptMessages[prompt_number].GetComponent<Image>();
        StartCoroutine(FadeOut(im));
        promptMessages[prompt_number].gameObject.SetActive(false);
    }

    private IEnumerator FadeIn(Image prompt_msg)
    {
        float alpha = prompt_msg.color.a;
        while (alpha <= 100f)
        {
            alpha += Time.deltaTime * speed;
            prompt_msg.color = new Color(prompt_msg.color.r, prompt_msg.color.g, prompt_msg.color.b, alpha);
        }

        yield return new WaitForSeconds(2f);
    }

    private IEnumerator FadeOut(Image prompt_msg)
    {
        float alpha = prompt_msg.color.a;
        while (alpha >= 0f)
        {
            alpha -= Time.deltaTime * speed;
            prompt_msg.color = new Color(prompt_msg.color.r, prompt_msg.color.g, prompt_msg.color.b, alpha);
        }

        yield return new WaitForSeconds(2f);
    }


}

