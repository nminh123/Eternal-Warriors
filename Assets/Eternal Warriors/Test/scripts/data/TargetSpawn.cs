using System;
using System.Collections;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class TargetSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject children;

        private void Update()
        {
            StartCoroutine(RecallAfterSecond(2));
        }

        IEnumerator RecallAfterSecond(float time)
        {
            if (children.gameObject == null)
            {
                Debug.Log("Khong tim thay object");
                yield break;
            }

            if (!children.activeInHierarchy)
            {
                yield return new WaitForSeconds(time);

                children.gameObject.SetActive(true);
            }
        }
    }
}