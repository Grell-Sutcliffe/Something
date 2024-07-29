using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BHSCamp
{
    public class ExitLevel : MonoBehaviour
    {
        public static event Action<LoadSceneMode> OnButtonPressed;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(
                () => SceneManager.LoadScene(0)
            );
        }
    }
}