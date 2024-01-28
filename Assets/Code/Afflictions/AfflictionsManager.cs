using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vintagerockets.untitledtowerdefense.afflictions
{
    public class AfflictionsManager : MonoBehaviour
    {
        public enum Affliction { Fire, Poison, Wet, Hidden }

        private List<Affliction> afflictionList = new();
        private Dictionary<Affliction, (float timeAvailable, float accumulation)> timerDictionary = new();

        public void ApplyAffliction(Affliction affliction)
        {
            if (!afflictionList.Contains(affliction))
                afflictionList.Add(affliction);
        }

        public void ApplyAffliction(Affliction affliction, float time)
        {
            if (!afflictionList.Contains(affliction))
            {
                afflictionList.Add(affliction);
                timerDictionary[affliction] = (Time.time + time, 0);
            }
        }

        public void RemoveAffliction(Affliction affliction)
        {
            afflictionList.Remove(affliction);
            timerDictionary.Remove(affliction);
        }

        private void UpdateAndRemove()
        {
            List<Affliction> toRemove = new();
            foreach (
                KeyValuePair<
                    Affliction,
                    (float timeAvailable, float accumulation)
                    >
                affliction in timerDictionary)
            {
                (float timeAvailable, float accumulation) value = affliction.Value;
                value.accumulation += Time.deltaTime;
                if (value.accumulation > 1)
                {
                    value.accumulation -= 1;
                    TickAffliction(affliction.Key);
                }
                if (Time.time > value.timeAvailable)
                {
                    toRemove.Add(affliction.Key);
                }
                else
                {
                    timerDictionary.Add(affliction.Key, value);
                }
            }
            foreach (Affliction removed in toRemove) RemoveAffliction(removed);
        }

        private void Update()
        {
            UpdateAndRemove();
        }

        private void TickAffliction(Affliction affliction)
        {

        }

    }
}
