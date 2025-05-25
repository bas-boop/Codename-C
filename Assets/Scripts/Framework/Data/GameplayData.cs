using UnityEngine;
using Random = UnityEngine.Random;

namespace Framework.Data
{
    public sealed class GameplayData : Singleton<GameplayData>
    {
        [SerializeField] private int[] pins;

        public string GetRandomPin()
        {
            if (pins.Length == 0)
                return null;
            
            foreach (int pin in pins)
            {
                if (pin is >= 0 and <= 9999)
                    continue;
                
                Debug.LogError($"Not a valid pin: {pin}");
            }
            
            int r = Random.Range(0, pins.Length);
            return pins[r].ToString("D4");
        }
    }
}