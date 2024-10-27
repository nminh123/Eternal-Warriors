using Unity.VisualScripting;
using UnityEngine;

public class LineKite : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject lineSprite;

    void Update()
    {
        Vector3 direction = pointB.position - pointA.position;
        float distance = direction.magnitude;

        // Đặt vị trí của line vào chính giữa hai điểm
        lineSprite.transform.position = pointA.position + direction / 2;

        // Đặt scale của line để kéo dài từ điểm A đến điểm B
        lineSprite.transform.localScale = new Vector3(distance, lineSprite.transform.localScale.y, lineSprite.transform.localScale.z);

        // Tính toán góc giữa hai điểm và xoay line
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        lineSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
