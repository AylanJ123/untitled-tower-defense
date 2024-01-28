using MyBox;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vintagerockets.untitledtowerdefense.enemies;

namespace com.vintagerockets.untitledtowerdefense.navigation
{
    public class Area : MonoBehaviour
    {

        [SerializeField, InitializationField] private AreaType type;
        private readonly List<Waypoint> registeredWaypoints;

        private void Start()
        {
            foreach (Waypoint waypoint in registeredWaypoints)
            {
                waypoint.arrival.AddListener(Arrival);
                waypoint.leftTowards.AddListener(Left);
            }
        }

        public enum AreaType
        {
            Forest, Water, Path
        }

        public void RegisterWaypoint(Waypoint waypoint)
        {
            registeredWaypoints.Add(waypoint);
        }

        private void Arrival(Enemy enemy)
        {
            ApplyEffectOnEnter(enemy);
        }

        private void Left(Waypoint newDestination, Enemy enemy)
        {
            if (newDestination.Area != this) RemoveEffectOnLeave(enemy);
        }

        private void ApplyEffectOnEnter(Enemy enemy)
        {
            switch (type)
            {
                case AreaType.Forest:
                    enemy.Afflictions.ApplyAffliction(afflictions.AfflictionsManager.Affliction.Hidden);
                    break;
                case AreaType.Water:
                    enemy.Afflictions.ApplyAffliction(afflictions.AfflictionsManager.Affliction.Wet);
                    break;
            }
        }

        private void RemoveEffectOnLeave(Enemy enemy)
        {
            switch (type)
            {
                case AreaType.Forest:
                    enemy.Afflictions.RemoveAffliction(afflictions.AfflictionsManager.Affliction.Hidden);
                    break;
                case AreaType.Water:
                    enemy.Afflictions.RemoveAffliction(afflictions.AfflictionsManager.Affliction.Wet);
                    break;
            }
        }

        private void OnDrawGizmosSelected()
        {
            List<Vector3> pos = new();
            foreach (Waypoint waypoint in registeredWaypoints)
                pos.Add(waypoint.transform.position);
            Gizmos.DrawLineStrip(pos.ToArray(), true);
        }

    }
}
