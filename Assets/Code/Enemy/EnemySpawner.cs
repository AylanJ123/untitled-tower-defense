using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vintagerockets.untitledtowerdefense.enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private Transform enemySpawnPoint;
        [SerializeField]
        private LevelWaves waves;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Waves());
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        private IEnumerator Waves()
        {
            foreach (var item in waves.wave) 
            {
                yield return new WaitForSeconds(item.cooldown);
                Instantiate(item.prefab,enemySpawnPoint,true);
                if (item.dialog != null)
                {
                    
                }
            }
            
        }
    }
}
