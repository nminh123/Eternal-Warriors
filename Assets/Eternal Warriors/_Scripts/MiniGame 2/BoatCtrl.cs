using System;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]

   
    public class BoatCtrl : MonoBehaviour
    {
        public Joystick joystick;
        public float speed;
        [SerializeField] private MiniGame2Manager manager;
        [SerializeField] private int bonusVal;

        private Vector2 moveVec;
        private Rigidbody2D rigid;

        public GameObject canvasEndGame;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            rigid.gravityScale = 0;
            canvasEndGame.SetActive(false);
        }

        private void Update()
        {
            moveVec.x = Input.GetAxisRaw("Horizontal");
            moveVec.y = Input.GetAxisRaw("Vertical");
            //moveVec.x = joystick.Horizontal;
            //moveVec.y = joystick.Vertical;
            //Vector2 movement = new Vector2(0, moveVec.y) *speed * Time.fixedDeltaTime;
            //rigid.MovePosition(rigid.position + movement);
        }

        private void FixedUpdate()
        {
            rigid.MovePosition(rigid.position + moveVec * speed * Time.fixedDeltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("bonus"))
            {
                this.gameObject.SetActive(false);
                canvasEndGame.SetActive(true);
                GameManager.instance.AddCoin(manager.score);
                Debug.Log("Thua roi!!");
            }

            if (other.gameObject.CompareTag("DeadEnd"))
            {
                this.gameObject.SetActive(false);
                canvasEndGame.SetActive(true);
                GameManager.instance.AddCoin(manager.score);
                Debug.Log("Thua roi!!");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("reward"))
            {
                manager.IncreaseScore(1);
                SoundManager.instance.PlaySound("Bonus");
                Debug.Log("Passed!!");
            }
        }
    }
}