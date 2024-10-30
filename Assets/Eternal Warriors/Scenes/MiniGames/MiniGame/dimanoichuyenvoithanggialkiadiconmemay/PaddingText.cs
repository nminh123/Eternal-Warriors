using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FadingText : MonoBehaviour
{
    public TextMeshProUGUI text; 
    public Image panel;
    public float fadeDuration = 3f; 
    public float delayBeforeFadeOut = 2f; 
    public float fadeInDuration = 2f; 

    private void Start()
    {
        StartCoroutine(FadeInAndOutElements());
    }

    private IEnumerator FadeInAndOutElements()
    {
        Color originalTextColor = text.color;
        Color originalPanelColor = panel.color;

        text.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 0);
        panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 0);

        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);

            text.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, alpha);
            panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, alpha);

            yield return null;
        }

        text.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 1);
        panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 1);

        yield return new WaitForSeconds(delayBeforeFadeOut);

        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            text.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, alpha);
            panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, alpha);

            yield return null;
        }

        text.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 0);
        panel.color = new Color(originalPanelColor.r, originalPanelColor.g, originalPanelColor.b, 0);
    }
}
