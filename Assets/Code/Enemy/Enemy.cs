using com.vintagerockets.untitledtowerdefense.afflictions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace vintagerockets.untitledtowerdefense.enemies
{
    public class Enemy : MonoBehaviour
    {
        private AfflictionsManager _affManager;
        public AfflictionsManager Afflictions
        {
            get
            {
                if (!_affManager) GetComponent<AfflictionsManager>();
                return _affManager;
            }
        }
    }
}
