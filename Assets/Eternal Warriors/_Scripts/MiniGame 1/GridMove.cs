using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f; // Tốc độ di chuyển của grid

    void Update()
    {
        MoveGrid();
    }

    private void MoveGrid()
    {
        // Kiểm tra đầu vào từ phím
        float horizontalInput = Input.GetAxis("Horizontal");

        // Tính toán chuyển động
        Vector3 newPosition = transform.position + new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime;

        // Cập nhật vị trí của grid
        transform.position = newPosition;
    }
}
