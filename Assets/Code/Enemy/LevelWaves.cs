using com.vintagerockets.untitledtowerdefense.dialogs;
using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vintagerockets.untitledtowerdefense.enemies
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Level Waves", fileName = "Level Waves - ")]
    public class LevelWaves : ScriptableObject
    {

        public List<EnemySpawnRule> wave;

        [Serializable]
        public class EnemySpawnRule
        {
            public GameObject prefab;
            public float cooldown;
            public Dialog dialog;
            [ConditionalField("dialog")] public float dialogDelay;
        }

    }
}
