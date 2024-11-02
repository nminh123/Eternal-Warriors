using UnityEngine;

public class TargetPointController : MonoBehaviour
{
    [SerializeField] private RectTransform targetPoint; 
    [SerializeField] private RectTransform beatBar;   
    [SerializeField] private float moveSpeed = 300f;    

    private bool movingRight = true;

    void Update()
    {
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        if (movingRight)
            targetPoint.anchoredPosition += Vector2.right * moveSpeed * Time.deltaTime;
        else
            targetPoint.anchoredPosition -= Vector2.right * moveSpeed * Time.deltaTime;

        if (targetPoint.anchoredPosition.x >= beatBar.rect.width / 2)
            movingRight = false;
        else if (targetPoint.anchoredPosition.x <= -beatBar.rect.width / 2)
            movingRight = true;
    }

}
