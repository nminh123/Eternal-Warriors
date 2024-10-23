using UnityEngine;
using UnityEngine.Serialization;

namespace Test.scripts.data.core
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Target : MonoBehaviour
    {
        private CircleCollider2D collision;
        [FormerlySerializedAs("manager")] [SerializeField] private ManagerTest managerTest;

        private void Start()
        {
            collision = GetComponent<CircleCollider2D>();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                managerTest.Score++;
                this.gameObject.SetActive(false);
                Debug.Log("Score: " + managerTest.Score);
            }
        }
    }
}