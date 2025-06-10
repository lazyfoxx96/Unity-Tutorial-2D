using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    public Image fadePanel;

    /*
    public bool isFadeIn = false;

    public float fadeTime = 3f;
    private float percent = 0f;

    private float timer = 0f;

    IEnumerator Start()
    {
        while(percent <= 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;

            fadePanel.color = new Color(fadePanel.color.r, fadePanel.color.g, fadePanel.color.b, percent);
            yield return null;
        }
    }

    void Start()
    {
        StartCoroutine(FadeRoutineA(3, true));
    }
    */

    public void OnFade(float fadeTime, Color color)
    {
        StartCoroutine(Fade(fadeTime, color));
    }

    IEnumerator Fade(float fadeTime, Color color)
    {
        float timer = 0f;
        float percent = 0f;
        //float value = 0f;

        while (percent <= 1f)
        {
            timer += Time.deltaTime;
            percent = timer / fadeTime;
            //value = isFadeIn ? percent : 1 - percent;

            fadePanel.color = new Color(color.r, color.g, color.b, percent);
            yield return null;
        }
    }
}
