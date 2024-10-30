using UnityEngine;

public class BeatIndicator : MonoBehaviour
{
    public RectTransform indicatorTransform;
    public float movementSpeed = 5f;

    private void Update()
    {
        // Di chuyển chỉ báo nhịp điệu
        indicatorTransform.anchoredPosition += Vector2.left * movementSpeed * Time.deltaTime;
    }

    public void MoveRandomly()
    {
        // Di chuyển ngẫu nhiên trong phạm vi
        float randomYPosition = Random.Range(-200f, 200f); // Điều chỉnh phạm vi theo yêu cầu
        indicatorTransform.anchoredPosition = new Vector2(indicatorTransform.anchoredPosition.x, randomYPosition);
    }
}
