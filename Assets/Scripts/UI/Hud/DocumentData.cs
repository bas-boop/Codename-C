using System;

namespace UI.Hud
{
    [Serializable]
    public struct DocumentData
    {
        public string name;
        public int pin;
        public string text;
        public bool isCorrupted;

        public bool Null()
        {
            return pin == 0;
        }
    }
}