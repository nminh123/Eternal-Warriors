using UnityEngine;

public class BeatIndicatorController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private RectTransform beatBar;
    private bool movingRight = true;
    [SerializeField] public bool beat;

    void Update()
    {
        MoveContinuously();
    }

    private void MoveContinuously()
    {
        if (movingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.localPosition.x >= beatBar.rect.width / 2)
            movingRight = false;
        else if (transform.localPosition.x <= -beatBar.rect.width / 2)
            movingRight = true;
    }


    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("target"))
        {
            beat = true; 
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("target"))
        {
            beat = false;
        }
    }

    public bool IsBeat()
    {
        return beat;
    }
}
