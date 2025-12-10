using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        // Ensure cursor is visible in main menu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void OnStartGameButtonPressed()
    {
        // Load the main game scene
       SceneManager.LoadScene("SampleScene");
    }
    
    public void OnExitGameButtonPressed()
    {
# if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
# endif        
        // Exit the application
        Application.Quit();
    }
}
