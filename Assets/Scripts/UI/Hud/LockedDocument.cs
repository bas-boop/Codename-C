using UnityEngine;
using TMPro;

using Framework.Data;
using UI.Hud;

public sealed class LockedDocument : MonoBehaviour
{
    [SerializeField] private GameObject lockedGameObject;
    [SerializeField] private GameObject unlockedGameObject;
    [SerializeField] private GameObject saveButton;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Window window;
    
    [SerializeField] private int pin = 1111;

    [SerializeField] private DocumentData documentData;
    
    private string _pinToCheck;

    private void Awake()
    {
        if (GameplayData.Exist)
        {
            _pinToCheck = GameplayData.Instance.GetRandomPin();

            documentData.name = window.GetWindowName();
            documentData.pin = int.Parse(_pinToCheck);
            documentData.text = text.text;   
        }
        
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

    public void SetData(DocumentData data)
    {
        documentData = data;
        
        // name
        pin = documentData.pin;
        text.text = documentData.text;
        
        saveButton.SetActive(false);
    }

    public DocumentData GetData() => documentData;

    private void SetState(bool target)
    {
        lockedGameObject.SetActive(!target);
        unlockedGameObject.SetActive(target);
    }
}
