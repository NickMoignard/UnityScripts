using GameSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

using GameSystems.Input;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField]
    private GameObject _audioServicePrefab;
    
    [SerializeField]
    private GameObject _inputServicePrefab;

    [SerializeField]
    private GameObject _uiServicePrefab;

    private void Awake()
    {
        InitializeServices();
        LoadInitialScene();
    }

    private void InitializeServices()
    {
        // Instantiate core services
        var audioService = InstantiateService<AudioService>(_audioServicePrefab);
        var inputService = InstantiateService<InputService>(_inputServicePrefab);
        
        // Register core services with the service locator
        ServiceLocator.RegisterService(audioService);
        ServiceLocator.RegisterService(inputService);
        
        // Make services persistent across scenes
        DontDestroyOnLoad(audioService.gameObject);
        DontDestroyOnLoad(inputService.gameObject);
        
    }

    private T InstantiateService<T>(GameObject prefab) where T : class
    {
        var instance = Instantiate(prefab);
        return instance.GetComponent<T>();
    }

    private void LoadInitialScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
