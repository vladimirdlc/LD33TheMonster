using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewritter : MonoBehaviour {
    public Text textBox;
    public float dialogWaitTime = 2.7f;
    public AudioSource lineBreakEffect;

    public string[] goatText = new string[] { "1. Laik's super awesome custom typewriter script", "2. You can click to skip to the next text", "3.All text is stored in a single string array", "4. Ok, now we can continue", "5. End Kappa" };

    int currentlyDisplayingText = 0;
    void Awake()
    {
        StartCoroutine(AnimateText());
    }

    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopCoroutine(AnimateText());
        currentlyDisplayingText++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText > goatText.Length + 1)
        {
            FadeOut();
            return;
        }
        StartCoroutine(AnimateText());
    }

    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds (in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        if (goatText.Length > currentlyDisplayingText)
        {
            for (int i = 0; i < (goatText[currentlyDisplayingText].Length + 1); i++)
            {
                if (i == 0) lineBreakEffect.Play();
                textBox.text = goatText[currentlyDisplayingText].Substring(0, i);
                yield return new WaitForSeconds(.03f);
            }
   
    
           yield return new WaitForSeconds(dialogWaitTime);
        }

        SkipToNextText();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCR());
    }

    private IEnumerator FadeOutCR()
    {
        float duration = 0.5f; //0.5 secs
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, currentTime / duration);
            textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
