using System;
using Framework.Data;
using UnityEngine;

public sealed class LockedDocument : MonoBehaviour
{
    [SerializeField] private GameObject lockedGameObject;
    [SerializeField] private GameObject unlockedGameObject;
    
    [SerializeField] private int pin = 1111;

    private string _pinToCheck;

    private void Awake()
    {
        if (GameplayData.Exist)
            _pinToCheck = GameplayData.Instance.GetRandomPin();
        
        SetState(false);
    }

    public void Check(string guess)
    {
        if (_pinToCheck != string.Empty
            && _pinToCheck == guess)
        {
            SetState(true);
            return;
        }
        
        if (guess == pin.ToString())
            SetState(true);
    }

    public string GetPin() => _pinToCheck ?? pin.ToString();

    private void SetState(bool target)
    {
        lockedGameObject.SetActive(!target);
        unlockedGameObject.SetActive(target);
    }
}
