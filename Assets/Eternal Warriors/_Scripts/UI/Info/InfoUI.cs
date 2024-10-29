using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoUI : MonoBehaviour
{
    public TextMeshProUGUI nameDiaDanh;
    public GameObject BG; 
    public float displayDuration = 2.5f;
    public float fadeDuration = 2.5f;
    public string diaDanhName;

    private void Start()
    {
        ShowInfo();
    }

    public void ShowInfo()
    {
        nameDiaDanh.text = diaDanhName;
        StartCoroutine(DisplayInfo());
    }

    private IEnumerator DisplayInfo()
    {
        nameDiaDanh.gameObject.SetActive(true);

        SpriteRenderer bgImage = BG.GetComponent<SpriteRenderer>();

        Color initialColor = new Color(0.1f, 0.1f, 0.1f);
        Color targetColor = new Color(1f, 1f, 1f);

        bgImage.color = initialColor;
        
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);
           
            bgImage.color = Color.Lerp(initialColor, targetColor, t);
            yield return null;
        }
        nameDiaDanh.gameObject.SetActive(false);
    }
}
