using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vintagerockets.untitledtowerdefense.afflictions
{
    public class Afflictions : MonoBehaviour
    {
        private enum Status { Fire, Poison, Wet, Hidden }
        private List<Status> afflictionList;
    }
}
