using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RhythmController : MonoBehaviour
{
    [SerializeField] private float rotation;
    [SerializeField] private GameObject rotatingObject;
    [SerializeField] private RectTransform beatBar;
    [SerializeField] private RectTransform targetPoint;
    [SerializeField] private GameObject beatIndicator;
    [SerializeField] private Slider scoreSlider;
    [SerializeField] private GameObject winPanel;
    private int score = 0;
    private const int maxScore = 10;
    [SerializeField] private float cooldownTime = 0.5f; 
    private float nextAllowedPressTime = 0f;

    void Start()
    {
        scoreSlider.maxValue = maxScore;
        scoreSlider.value = 0;
        scoreSlider.interactable = false;
        winPanel.SetActive(false);
    }

    void Update()
    {
        if (score < maxScore)
        {
            CheckForBeatInput();
        }
    }

    private void CheckForBeatInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAllowedPressTime)
        {
            nextAllowedPressTime = Time.time + cooldownTime;
            if (beatIndicator.TryGetComponent<BeatIndicatorController>(out var beatController) && beatController.beat)
            {
                score = Mathf.Min(maxScore, score + 1);
                Debug.Log("Great! You hit the beat!");
            }
            else
            {
                score = Mathf.Max(0, score - 1);
                Debug.Log("Missed the beat!");
            }

            scoreSlider.value = score;
            MoveBeatIndicatorRandomly();

            if (score == maxScore)
            {
                GameOver();
            }
            StartCoroutine(RotateObject());
        }
    }

    private void MoveBeatIndicatorRandomly()
    {
        float randomX = Random.Range(-beatBar.rect.width / 2, beatBar.rect.width / 2);
        beatIndicator.transform.localPosition = new Vector3(randomX, beatIndicator.transform.localPosition.y, beatIndicator.transform.localPosition.z);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    private IEnumerator RotateObject()
    {
        //isRotating = true;
        Quaternion originalRotation = rotatingObject.transform.rotation;

        rotatingObject.transform.Rotate(0, 0, rotation); 

        yield return new WaitForSeconds(0.2f); 

        rotatingObject.transform.rotation = originalRotation; 
        //isRotating = false;
    }
}
