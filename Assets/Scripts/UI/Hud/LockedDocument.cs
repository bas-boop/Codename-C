using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Framework.Data;
using UI.Hud;

public sealed class LockedDocument : MonoBehaviour
{
    [SerializeField] private GameObject lockedGameObject;
    [SerializeField] private GameObject unlockedGameObject;
    [SerializeField] private Button saveButton;
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
        gameObject.SetActive(false);
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

    public void SetData(DocumentData data, UnityAction action)
    {
        documentData = data;

        window.SetWindowName(documentData.name);
        pin = documentData.pin;
        text.text = documentData.text;
        
        SetState(true);
        
        saveButton.onClick.RemoveAllListeners();
        saveButton.onClick.AddListener(action);
    }

    public DocumentData GetData() => documentData;

    private void SetState(bool target)
    {
        lockedGameObject.SetActive(!target);
        unlockedGameObject.SetActive(target);
    }
}
