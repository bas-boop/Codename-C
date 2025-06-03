using System.Collections.Generic;
using UnityEngine;

using UI.Hud;

namespace Framework.Data
{
    public sealed class DataSpawner : MonoBehaviour
    {
        [SerializeField] private Transform windowParent;
        [SerializeField] private GameObject lockedDocumentWindow;
        [SerializeField] private DocumentExposer documentExposer;
        [SerializeField] private TaskBar taskBar;
        
        private void Start()
        {
            if (!GameplayData.Exist)
                return;
            
            List<DocumentData> datas = GameplayData.Instance?.GetSavedWindows();
            
            if (datas.Count == 0)
                return;

            foreach (DocumentData data in datas)
            {
                GameObject w = Instantiate(lockedDocumentWindow, windowParent);
                
                w.GetComponent<LockedDocument>().SetData(data, () => documentExposer.AddUpload(data));
                
                taskBar.AddTask(w.GetComponent<Window>());
            }
            
        }
    }
}