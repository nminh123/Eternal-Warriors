using System;
using UnityEngine;

namespace Test.scripts.data.core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Tốc độ di chuyển
        private Rigidbody2D rb; // Rigidbody2D của nhân vật
        private Vector2 movement; // Vector di chuyển

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            // Lấy input từ bàn phím
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Nếu không muốn nhân vật di chuyển chậm hơn khi di chuyển chéo
            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }
        }

        void FixedUpdate()
        {
            // Di chuyển nhân vật
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}