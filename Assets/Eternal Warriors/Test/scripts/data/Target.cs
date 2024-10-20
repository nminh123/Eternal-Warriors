using UnityEngine;

namespace Test.scripts.data.core
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Target : MonoBehaviour
    {
        private CircleCollider2D collision;
        [SerializeField] private GameManager manager;

        private void Start()
        {
            collision = GetComponent<CircleCollider2D>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                manager.score++;
                this.gameObject.SetActive(false);
                Debug.Log(manager.score);
            }
        }
    }
}