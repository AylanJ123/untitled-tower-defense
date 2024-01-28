using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.vintagerockets.untitledtowerdefense.levels
{
    public class EndGame : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(Win());
        }
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene("LOSE");
        }
        private IEnumerator Win()
        {
            yield return new WaitForSeconds(300);
            SceneManager.LoadScene("WIN");
        }
    }
}
