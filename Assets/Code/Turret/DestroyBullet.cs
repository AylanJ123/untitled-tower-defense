using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vintagerockets.untitledtowerdefense.towers
{
    public class DestroyBullet : MonoBehaviour
    {
        [SerializeField]
        private float seconds;
        void Start()
        {
            StartCoroutine(DestroyInSeconds());
        }
        private IEnumerator DestroyInSeconds()
        {
            yield return new WaitForSeconds(seconds);
            Destroy(gameObject);
        }

    }
}
