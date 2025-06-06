using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public sealed class FolderWindow : Window
    {
        [SerializeField] private Button buttonPrefab;
        [SerializeField] private Transform gridTransform;
        [SerializeField] private List<Window> windowsToOpen;
        [SerializeField] private TaskBar taskBar;

        protected override void Awake()
        {
            base.Awake();

            if (windowsToOpen.Count == 0)
                return;
            
            if (taskBar == null)
                taskBar = FindAnyObjectByType<TaskBar>();
            
            foreach (Window window in windowsToOpen)
            {
                Button newTaskButton = Instantiate(buttonPrefab, gridTransform);
                newTaskButton.image.sprite = window.GetWindowIcon();
                newTaskButton.onClick.AddListener(() => taskBar.AddTaskAndSetActive(window));
            }
        }
    }
}