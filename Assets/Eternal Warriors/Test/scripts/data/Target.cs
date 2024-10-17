using UnityEngine;

namespace Test.scripts.data.core
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Target : MonoBehaviour
    {
        private CircleCollider2D collision;

        private void Start()
        {
            collision = GetComponent<CircleCollider2D>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                JsonData.score++;
                this.gameObject.SetActive(false);
            }
        }
    }
}