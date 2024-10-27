using System;
using System.Collections;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MapHandle : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;
        [SerializeField] private Vector2 offset;

        private void Start()
        {
            StartCoroutine(WaitToIncreaseSpeed(5f));
        }

        private IEnumerator WaitToIncreaseSpeed(float val)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(val);
                speed += 0.2f;
            }
        }
    
        private void Update()
        {
            offset = new Vector2(0, Time.time * speed);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }   
}