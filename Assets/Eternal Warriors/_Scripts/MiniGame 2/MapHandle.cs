using System.Collections;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MapHandle : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;
        [SerializeField] private Vector2 offset;
        [SerializeField] private GameObject pBoat;

        private void Start()
        {
            StartCoroutine(WaitToIncreaseSpeed(5f));
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
            offset = new Vector2(0, Time.time * speed);
            GetComponent<Renderer>().material.mainTextureOffset = offset;

            if (!pBoat.activeInHierarchy)
            {
                speed = 0;
                StopCoroutine(WaitToIncreaseSpeed(5f));
            }
        }
    }   
}