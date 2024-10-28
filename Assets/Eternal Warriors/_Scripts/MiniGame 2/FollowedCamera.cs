using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class FollowedCamera : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            transform.position += new Vector3(0,speed * Time.deltaTime,0);
        }
    }
}