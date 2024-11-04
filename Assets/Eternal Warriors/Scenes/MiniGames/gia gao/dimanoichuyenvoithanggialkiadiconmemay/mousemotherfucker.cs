using UnityEngine;
using UnityEngine.EventSystems;

public class ShowGameObjectOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverObject; // GameObject sẽ hiển thị khi di chuột vào Button

    void Start()
    {
        // Đảm bảo GameObject bị ẩn khi bắt đầu
        if (hoverObject != null)
        {
            hoverObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Hiển thị GameObject khi di chuột vào Button
        if (hoverObject != null)
        {
            hoverObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Ẩn GameObject khi rời chuột khỏi Button
        if (hoverObject != null)
        {
            hoverObject.SetActive(false);
        }
    }
}
