using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.vintagerockets.untitledtowerdefense
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(1);
            SceneManager.UnloadSceneAsync(0);
        }

    }
}