using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public class BoatCtrl : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private MiniGame2Manager manager;
        [SerializeField] private int bonusVal;

        private Vector2 moveVec;
        private Rigidbody2D rigid;

        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            rigid.gravityScale = 0;
        }

        private void Update()
        {
            moveVec.x = Input.GetAxisRaw("Horizontal");
            moveVec.y = Input.GetAxisRaw("Vertical");

            if (moveVec.magnitude > 1)
            {
                moveVec.Normalize();
            }
        }

        private void FixedUpdate()
        {
            rigid.MovePosition(rigid.position + moveVec * speed * Time.fixedDeltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("bonus"))
            {
                manager.IncreaseScore(bonusVal);
                Debug.Log("Score: " + manager.score);
            }
        }
    }
}