using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public sealed class TaskBar : MonoBehaviour
    {
        [SerializeField] private Button buttonPrefab;
        [SerializeField] private List<Window> standardTasks;
    
        private readonly List<Window> _windows = new ();
        private readonly List<Button> _tasks = new ();

        private void Start() => InitTaskBar();

        public void AddTask(Window target)
        {
            if (_windows.Contains(target))
                return;

            Button newTaskButton = Instantiate(buttonPrefab, transform);
            newTaskButton.onClick.AddListener(target.ToggleActive);
            _tasks.Add(newTaskButton);
            _windows.Add(target);

            newTaskButton.GetComponentInChildren<TMP_Text>().text = target.GetWindowName(); // temp until art
        }

        private void InitTaskBar()
        {
            for (int i = 0; i < standardTasks.Count; i++)
            {
                AddTask(standardTasks[i]);
                _tasks[i].gameObject.SetActive(true);
            }
        }
    }
}
