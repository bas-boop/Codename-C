using System;
using UnityEngine;

namespace UI.Hud
{
    [Serializable]
    public struct DocumentData
    {
        public string name;
        public int pin;
        public string text;
        public bool isCorrupted;
        public Sprite icon;

        public bool Null()
        {
            return pin == 0;
        }
    }
}