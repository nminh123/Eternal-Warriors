using System;
using System.Collections;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class FollowedCamera : MonoBehaviour
    {
        public float speed;
        [SerializeField] private GameObject pBoat;

        private void Start()
        {
            StartCoroutine(WaitToIncreaseSpeed(3f));
        }

        private IEnumerator WaitToIncreaseSpeed(float time)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(time);
                speed += 0.2f;
            }
        }
        
        private void Update()
        {
            transform.position += new Vector3(0,speed * Time.deltaTime,0);

            if (!pBoat.activeInHierarchy)
            {
                speed = 0;
                StopCoroutine(WaitToIncreaseSpeed(3f));
            }
        }
    }
}