using UnityEngine;

using Framework.Data;

namespace UI.Hud
{
    public class SaveDocumenter : MonoBehaviour
    {
        [SerializeField] private LockedDocument thisWindow;
        
        private DocumentData _documentDataToSave;

        private void Start()
        {
            if (thisWindow == null)
                thisWindow = GetComponent<LockedDocument>();

            _documentDataToSave = thisWindow.GetData();
        }

        public void SaveDocument()
        {
            GameplayData.Instance.SaveWindow(_documentDataToSave);
        }
    }
}