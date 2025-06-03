using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Framework;

namespace UI.Hud
{
    public sealed class DocumentExposer : MonoBehaviour
    {
        [SerializeField] private SceneSwitcher sceneSwitcher;
        [SerializeField] private ExposedDocumentsUI exposedDocumentsUI;
        [SerializeField] private int amountCanUpload = 5;
        [SerializeField] private int amountToBeCorrupted = 3;
        [SerializeField] private List<DocumentData> uploads;
        [SerializeField] private DocumentData test;

        public void Test() => AddUpload(test);
        
        public void AddUpload(DocumentData data)
        {
            if (uploads.Contains(data))
                return;
            
            uploads.Add(data);

            if (uploads.Count > amountCanUpload)
                uploads.RemoveAt(0);
            
            exposedDocumentsUI.UpdateText(uploads.ToArray());
        }

        public void Upload()
        {
            int countCorrupted = uploads.Count(documentData => documentData.isCorrupted);
            sceneSwitcher.SetAndLoadScene(countCorrupted >= amountToBeCorrupted ? "W" : "L");
        }
    }
}