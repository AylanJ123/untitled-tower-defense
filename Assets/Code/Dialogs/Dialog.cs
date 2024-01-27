using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.vintagerockets.untitledtowerdefense.dialogs
{

    [CreateAssetMenu(menuName = "Scriptable Objects/Dialog", fileName = "Dialog - ")]
    public class Dialog : ScriptableObject
    {

        public List<DialogLine> lines;

        [Serializable]
        public class DialogLine
        {
            public string text;
            public Sprite sprite;
            public bool rightSided;
        }

    }
}
