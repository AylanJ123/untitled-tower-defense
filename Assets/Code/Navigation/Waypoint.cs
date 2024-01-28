using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using vintagerockets.untitledtowerdefense.enemies;

namespace com.vintagerockets.untitledtowerdefense.navigation
{
    public class Waypoint : MonoBehaviour
    {

        public enum WaypointTags
        {
            Next_In_Exit, Next_To_Water
        }

        [field: SerializeField] public Area Area { get; }

        public UnityEvent<Enemy> arrival;
        public UnityEvent<Waypoint, Enemy> leftTowards;

        [Foldout("Normal References", true), SerializeField, InitializationField]
        private Waypoint nextLogically;

        [SerializeField, InitializationField]
        private List<Waypoint> nextAhead;

        [SerializeField, InitializationField]
        private List<Waypoint> secondaryWays;

        [Foldout("Area References", true), SerializeField, InitializationField]
        private Waypoint nextInPath;

        [SerializeField, InitializationField]
        private List<Waypoint> nextAheadInArea;

        [Foldout("Tags and labels", true), SerializeField, InitializationField]
        private bool isEntrance;

        [SerializeField, InitializationField]
        private bool isExit;

        [field: SerializeField, InitializationField]
        public List<WaypointTags> Tags { get; }

        private void Awake()
        {
            Area.RegisterWaypoint(this);
        }

        public Vector3 FollowWaypoint(Waypoint oldWaypoint, Enemy enemy)
        {
            oldWaypoint.leftTowards.Invoke(this, enemy);
            arrival.Invoke(enemy);
            return transform.position;
        }

    }
}
