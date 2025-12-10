using GameSystems.Input;
using UnityEngine;

namespace Scenes.MainMenu
{
    public class SceneManager : MonoBehaviour
    {
        private InputService _inputService;

        public void Awake()
        {
            _inputService = ServiceLocator.Get<InputService>();
        }

        private void Start()
        {
            InitializeScene();
        }
        
        private void InitializeScene()
        {
            // Set up the scene   
        }
    }
}
